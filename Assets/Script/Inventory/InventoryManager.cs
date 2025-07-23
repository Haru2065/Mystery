using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[���擾�����A�C�e�����Ǘ�����}�l�[�W���[
/// </summary>
public class InventoryManager : MonoBehaviour
{
    //�C���x���g���}�l�[�W���[�p�̃C���X�^���X
    private static InventoryManager instacne;

    /// <summary>
    /// �C���x���g���}�l�[�W���̃C���X�^���X�̃Q�b�^�[
    /// </summary>
    public static InventoryManager Instance
    {
        get => instacne;
    }

    [SerializeField]
    private List<ItemStatus> inventoryItems = new List<ItemStatus>();

    /// <summary>
    /// �C���X�^���X�����A���ɃC���X�^���X������΃I�u�W�F�N�g������
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
            Debug.LogWarning("�ǉ����悤�Ƃ����A�C�e����null�ł�!");
            return;
        }

        inventoryItems.Add(item);

        Debug.Log($"�A�C�e���ǉ�{item.ItemName}");
    }

    /// <summary>
    /// �C���x���g�����̃A�C�e�����폜
    /// </summary>
    /// <param name="item">�폜����A�C�e��</param>
    public void RemoveItem(ItemStatus item)
    {
        if (inventoryItems.Contains(item))
        {
            inventoryItems.Remove(item);
            Debug.Log($"�A�C�e������:{item.ItemName}");
        }
        else
        {
            Debug.Log("�����Ώۂ̃A�C�e�����C���x���g���ɑ��݂��܂���");
        }
    }

    /// <summary>
    /// ���݂̃C���x���g�����̑S�A�C�e�����擾
    /// </summary>
    /// <returns>�A�C�e���̃��X�g</returns>
    public List<ItemStatus> GetInventoryItems()
    {
        return inventoryItems;
    }
}