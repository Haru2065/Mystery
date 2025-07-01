using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// シャッターを空けるギミックを表示するためのアクションスクリプト
/// </summary>
public class ShutterAction : MonoBehaviour
{
    [SerializeField]
    [Tooltip("シャッターを開くパスワード入力画面")]
    private GameObject openShutterPassword_Window;

    [SerializeField]
    [Tooltip("当たり判定スクリプト")]
    private MapHitManager hitManager;

    [SerializeField]
    [Tooltip("プレイヤーマネージャー")]
    private PlayerManager playerManager;

    [SerializeField]
    private Tilemap shutterTile;

    [SerializeField]
    private ColorPassWardManager colorPassWardManager;

    private void Start()
    {
        //最初はパスワード入力画面を非表示
        openShutterPassword_Window.SetActive(false);
    }

    private void Update()
    {
        //もしシャッターの前にいれば、イベントアクションを行えて、Fキーを押せるようにする
        if(playerManager.IsEventAction)
        {
            //もしFキーが押されたらパスワード入力画面を開く
            if(Input.GetKeyDown(KeyCode.F))
            {
                openShutterPassword_Window.SetActive(true);
            }
        }

        //パスワード成功したらシャッターを開ける
        if (colorPassWardManager.IsSuccess)
        {
            hitManager.RemoveEventTileMap(shutterTile);
            Destroy(shutterTile.gameObject);
        }

    }

}
