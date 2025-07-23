using UnityEngine;

/// <summary>
/// �V�[����̃A�C�e���ɕt����X�N���v�g�B�v���C���[���߂Â��Ď擾�ł���悤�ɂ���
/// </summary>
public class ItemPocket : MonoBehaviour
{
    private static ItemPocket instance;

    public static ItemPocket Instance
    {
        get => instance;
    }

    [SerializeField]
    [Tooltip("���̃A�C�e����ID")]
    public string TargetItemID;

    [SerializeField]
    [Tooltip("�A�C�e�����ꊇ�Ǘ�����Ă���SO")]
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
    /// �A�C�e�����擾���ăC���x���g���ɒǉ��A�I�u�W�F�N�g���폜
    /// </summary>
    public void PickUpItem()
    {
        if (itemDataSO == null || string.IsNullOrEmpty(TargetItemID))
        {
            Debug.LogWarning("ItemData���ݒ肳��Ă��Ȃ��A�܂���ID����ł�");
            return;
        }
        
        ItemStatus foundItem = itemDataSO.itemList.Find(itemData => itemData.ItemId == TargetItemID);

        if (foundItem != null)
        {
            InventoryManager.Instance.AddItem(foundItem);
            Debug.Log($"�A�C�e��:{foundItem.ItemName}���擾���܂���");
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning($"itemData����ID:{TargetItemID}�̃A�C�e����������܂���I�I");
        }
    }

    // �v���C���[���͈͂ɓ������Ƃ�
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("�v���C���[���߂Â��܂����i�擾�\�j");
        }
    }

    // �v���C���[���͈͂��痣�ꂽ�Ƃ�
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("�v���C���[������܂���");
        }
    }
}
