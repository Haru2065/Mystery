using UnityEngine;

/// <summary>
/// シーン上のアイテムに付けるスクリプト。プレイヤーが近づいて取得できるようにする
/// </summary>
public class ItemPocket : MonoBehaviour
{
    private static ItemPocket instance;

    public static ItemPocket Instance
    {
        get => instance;
    }

    [SerializeField]
    [Tooltip("このアイテムのID")]
    public string TargetItemID;

    [SerializeField]
    [Tooltip("アイテムが一括管理されているSO")]
    private ItemData itemDataSO;

    private bool isPlayerNear;

    public bool IsPlayerNear
    {
        get => isPlayerNear;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        isPlayerNear = false;
    }

    

    /// <summary>
    /// アイテムを取得してインベントリに追加、オブジェクトを削除
    /// </summary>
    public void PickUpItem()
    {
        if (itemDataSO == null || string.IsNullOrEmpty(TargetItemID))
        {
            Debug.LogWarning("ItemDataが設定されていない、またはIDが空です");
            return;
        }
        
        ItemStatus foundItem = itemDataSO.itemList.Find(itemData => itemData.ItemId == TargetItemID);

        if (foundItem != null)
        {
            InventoryManager.Instance.AddItem(foundItem);
            Debug.Log($"アイテム:{foundItem.ItemName}を取得しました");
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning($"itemData内にID:{TargetItemID}のアイテムが見つかりません！！");
        }
    }

    // プレイヤーが範囲に入ったとき
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("プレイヤーが近づきました（取得可能）");
        }
    }

    // プレイヤーが範囲から離れたとき
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("プレイヤーが離れました");
        }
    }
}
