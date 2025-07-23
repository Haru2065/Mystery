using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// シャッターのパスワードギミック
/// </summary>
public class ShutterAction : MonoBehaviour
{
    [SerializeField]
    [Tooltip("カラーパスワード解除型のシャッターイベントか")]
    private bool isColorPassWord_ShutterAction;

    [SerializeField]
    [Tooltip("数字パスワード解除型のシャッターイベントか")]
    private bool isNumberPassWord_ShutterAction;

    [SerializeField]
    [Tooltip("シャッターを開くカラーパスワード入力画面")]
    private GameObject openShutterColorPassword_Window;

    [SerializeField]
    [Tooltip("シャッタを開く数字パスワード画面")]
    private GameObject openShutterNumberPassword_Window;

    [SerializeField]
    [Tooltip("当たり判定スクリプト")]
    private MapHitManager hitManager;

    [SerializeField]
    [Tooltip("プレイヤーマネージャー")]
    private PlayerManager playerManager;

    [SerializeField]
    [Tooltip("カラーパスワードのマネージャ")]
    private ColorPassWardManager colorPassWardManager;

    [SerializeField]
    [Tooltip("数字パスワードマネージャ")]
    private NumberLock numberLock;

    [SerializeField]
    [Tooltip("カラーパスワード型シャッターのイベントタイル")]
    private Tilemap colorShutterTile;

    [SerializeField]
    [Tooltip("数字パスワード型シャッターのイベントタイル")]
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

        // カラーパスワード型
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

        // 数字パスワード型
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
