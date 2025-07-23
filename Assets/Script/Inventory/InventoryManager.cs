using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーが取得したアイテムを管理するマネージャー
/// </summary>
public class InventoryManager : MonoBehaviour
{
    //インベントリマネージャー用のインスタンス
    private static InventoryManager instacne;

    /// <summary>
    /// インベントリマネージャのインスタンスのゲッター
    /// </summary>
    public static InventoryManager Instance
    {
        get => instacne;
    }

    [SerializeField]
    private List<ItemStatus> inventoryItems = new List<ItemStatus>();

    /// <summary>
    /// インスタンス化し、既にインスタンスがあればオブジェクトを消去
    /// </summary>
    private void Awake()
    {
        if (instacne == null)
        {
            instacne = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(ItemStatus item)
    {
        if (item == null)
        {
            Debug.LogWarning("追加しようとしたアイテムがnullです!");
            return;
        }

        inventoryItems.Add(item);

        Debug.Log($"アイテム追加{item.ItemName}");
    }

    /// <summary>
    /// インベントリ内のアイテムを削除
    /// </summary>
    /// <param name="item">削除するアイテム</param>
    public void RemoveItem(ItemStatus item)
    {
        if (inventoryItems.Contains(item))
        {
            inventoryItems.Remove(item);
            Debug.Log($"アイテム消去:{item.ItemName}");
        }
        else
        {
            Debug.Log("消去対象のアイテムがインベントリに存在しません");
        }
    }

    /// <summary>
    /// 現在のインベントリ内の全アイテムを取得
    /// </summary>
    /// <returns>アイテムのリスト</returns>
    public List<ItemStatus> GetInventoryItems()
    {
        return inventoryItems;
    }
}