using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの基本操作を管理しているスクリプト
/// イベント系以外の操作をここに書く
/// </summary>
public class PlayerConfig : MonoBehaviour
{
    private PushableObject nearChair = null;

    [SerializeField]
    [Tooltip("プレイヤーの操作スクリプト")]
    private PlayerMove playerMove;

    /// <summary>
    /// playerMoveから近くの椅子情報を受け取る
    /// </summary>
    /// <param name="chair">椅子</param>
    public void SetNearChair(PushableObject chair)
    {
        nearChair = chair;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (!playerMove.IsOnChair() && nearChair != null)
            {
                playerMove.SitOnChair(nearChair);
            }

            else if(playerMove.IsOnChair())
            {
                playerMove.GetOffChair();
            }
        }
        
        // プレイヤーが近くにいて、Eキーを押したら取得
        if (ItemPocket.Instance.IsPlayerNear)
        {
           if(Input.GetKeyDown(KeyCode.E))
           {
                ItemPocket.Instance.PickUpItem();
           }
        }
    }
}
