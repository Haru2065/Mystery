using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// �V���b�^�[�̃p�X���[�h�M�~�b�N
/// </summary>
public class ShutterAction : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�J���[�p�X���[�h�����^�̃V���b�^�[�C�x���g��")]
    private bool isColorPassWord_ShutterAction;

    [SerializeField]
    [Tooltip("�����p�X���[�h�����^�̃V���b�^�[�C�x���g��")]
    private bool isNumberPassWord_ShutterAction;

    [SerializeField]
    [Tooltip("�V���b�^�[���J���J���[�p�X���[�h���͉��")]
    private GameObject openShutterColorPassword_Window;

    [SerializeField]
    [Tooltip("�V���b�^���J�������p�X���[�h���")]
    private GameObject openShutterNumberPassword_Window;

    [SerializeField]
    [Tooltip("�����蔻��X�N���v�g")]
    private MapHitManager hitManager;

    [SerializeField]
    [Tooltip("�v���C���[�}�l�[�W���[")]
    private PlayerManager playerManager;

    [SerializeField]
    [Tooltip("�J���[�p�X���[�h�̃}�l�[�W��")]
    private ColorPassWardManager colorPassWardManager;

    [SerializeField]
    [Tooltip("�����p�X���[�h�}�l�[�W��")]
    private NumberLock numberLock;

    [SerializeField]
    [Tooltip("�J���[�p�X���[�h�^�V���b�^�[�̃C�x���g�^�C��")]
    private Tilemap colorShutterTile;

    [SerializeField]
    [Tooltip("�����p�X���[�h�^�V���b�^�[�̃C�x���g�^�C��")]
    private Tilemap numberShutterTile;

    // Start is called before the first frame update
    void Start()
    {
        openShutterColorPassword_Window.SetActive(false);

        openShutterNumberPassword_Window.SetActive(false);
    }

    void Update()
    {
        Vector3 playerFront = playerManager.transform.position + (playerManager.transform.up * 1f);

        // �J���[�p�X���[�h�^
        if (isColorPassWord_ShutterAction)
        {
            Vector3Int cell = colorShutterTile.WorldToCell(playerFront);
            if (colorShutterTile.HasTile(cell) && Input.GetKeyDown(KeyCode.F))
            {
                openShutterColorPassword_Window.SetActive(true);
            }

            if (colorPassWardManager.IsSuccess)
            {
                hitManager.RemoveEventTileMap(colorShutterTile);
                Destroy(colorShutterTile.gameObject);
            }
        }

        // �����p�X���[�h�^
        if (isNumberPassWord_ShutterAction)
        {
            Vector3Int cell = numberShutterTile.WorldToCell(playerFront);
            if (numberShutterTile.HasTile(cell) && Input.GetKeyDown(KeyCode.F))
            {
                openShutterNumberPassword_Window.SetActive(true);
            }

            if (numberLock.IsOpen)
            {
                hitManager.RemoveEventTileMap(numberShutterTile);
                Destroy(numberShutterTile.gameObject);
            }
        }
    }

}
