using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// �V���b�^�[���󂯂�M�~�b�N��\�����邽�߂̃A�N�V�����X�N���v�g
/// </summary>
public class ShutterAction : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�V���b�^�[���J���p�X���[�h���͉��")]
    private GameObject openShutterPassword_Window;

    [SerializeField]
    [Tooltip("�����蔻��X�N���v�g")]
    private MapHitManager hitManager;

    [SerializeField]
    [Tooltip("�v���C���[�}�l�[�W���[")]
    private PlayerManager playerManager;

    [SerializeField]
    private Tilemap shutterTile;

    [SerializeField]
    private ColorPassWardManager colorPassWardManager;

    private void Start()
    {
        //�ŏ��̓p�X���[�h���͉�ʂ��\��
        openShutterPassword_Window.SetActive(false);
    }

    private void Update()
    {
        //�����V���b�^�[�̑O�ɂ���΁A�C�x���g�A�N�V�������s���āAF�L�[��������悤�ɂ���
        if(playerManager.IsEventAction)
        {
            //����F�L�[�������ꂽ��p�X���[�h���͉�ʂ��J��
            if(Input.GetKeyDown(KeyCode.F))
            {
                openShutterPassword_Window.SetActive(true);
            }
        }

        //�p�X���[�h����������V���b�^�[���J����
        if (colorPassWardManager.IsSuccess)
        {
            hitManager.RemoveEventTileMap(shutterTile);
            Destroy(shutterTile.gameObject);
        }

    }

}
