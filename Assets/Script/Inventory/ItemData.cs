using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムのデータをSOで管理
/// </summary>
[CreateAssetMenu(fileName = "ItemData", menuName = "Inventory/ItemData")]
public class ItemData : ScriptableObject
{
    public List<ItemStatus> itemList;

   
}
