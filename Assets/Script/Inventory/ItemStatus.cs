using System;
using UnityEngine;

[Serializable]
public class ItemStatus
{
    [Tooltip("�A�C�e����ID")]
    public string ItemId;

    [Header("�A�C�e���̖��O")]
    public string ItemName;
    
    [Header("�A�C�e���̃A�C�R��")]
    public Sprite Icon;

    [TextArea]
    [Header("�A�C�e�����")]
    public string description;
}