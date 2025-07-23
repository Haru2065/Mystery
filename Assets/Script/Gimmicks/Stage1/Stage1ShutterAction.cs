using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Stage1ShutterAction : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�����p�X���[�h���")]
    private GameObject numberPassWordWindow;


    [SerializeField]
    [Tooltip("�����p�X���[�h�X�N���v�g")]
    private NumberLock numberLock;

    [SerializeField]
    [Tooltip("�v���C���[�}�l�[�W��")]
    private PlayerManager playerManager;

    [SerializeField]
    private Tilemap shutterTile;

    [SerializeField]
    private MapHitManager hitManager;

    // Start is called before the first frame update
    void Start()
    {
        numberPassWordWindow.SetActive(false);
    }

    private void Update()
    {
        if(playerManager.IsEventAction)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                numberPassWordWindow.SetActive(true);
            }
        }

        if(numberLock.IsOpen)
        {
            hitManager.RemoveEventTileMap(shutterTile);

            numberPassWordWindow.SetActive(false);

            Destroy(shutterTile.gameObject);
        }
    }
}
