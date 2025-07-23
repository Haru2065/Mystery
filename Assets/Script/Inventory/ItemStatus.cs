using System;
using UnityEngine;

[Serializable]
public class ItemStatus
{
    [Tooltip("アイテムのID")]
    public string ItemId;

    [Header("アイテムの名前")]
    public string ItemName;
    
    [Header("アイテムのアイコン")]
    public Sprite Icon;

    [TextArea]
    [Header("アイテム情報")]
    public string description;
}