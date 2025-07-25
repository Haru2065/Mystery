using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �C���x���g����UI���R���g���[������X�N���v�g
/// </summary>
public class InventoryUIController : MonoBehaviour
{
    [SerializeField]
    [Header("�X���b�g�̐e�I�u�W�F�N�g")]
    private List<Button> slotButtons;

    [SerializeField]
    [Header("�X���b�g���̃A�C�R��Image")]
    private List<Image> slotIcons;

    [Header("�ڍו\��UI")]
    public TMP_Text itemNameText;
    public Image itemIconImage;
    public TMP_Text itemDescriptionText;

    [Header("�g�p�{�^��")]
    public Button useButton;

    [Header("�E����UI")]

    [SerializeField]
    [Tooltip("�A�C�e������\������^�O")]
    private GameObject itemNameObject;

    [SerializeField]
    [Tooltip("�e���A�C�e���A�C�R��")]
    private GameObject mainItemIcon;

    [SerializeField]
    [Tooltip("�C���[�W�A�C�e���A�C�R��")]
    private Image itemIcon;

    [SerializeField]
    [Tooltip("�A�C�e�����")]
    private GameObject itemDescriptionObject;

    [Header("�C���x���g�����J���A�C�R��")]

    [SerializeField]
    [Tooltip("�C���x���g���A�C�R��")]
    private GameObject inventoryIcon;


    private ItemStatus selectedItem = null;

    [SerializeField]
    private List<ItemStatus> currentItems;



    // Start is called before the first frame update
    void Start()
    {
        //�e�C���x���g��UI���\��
        mainItemIcon.SetActive(false);
        itemNameObject.SetActive(false);
        itemDescriptionObject.SetActive(false);

        itemIconImage.gameObject.SetActive(false);

        //�A�C�e���X���b�g�����ׂĔ�\��
        foreach (var button in slotButtons)
        {
            button.gameObject.SetActive(false);
        }

        //�X���b�g�A�C�R������\��
        foreach(var slots in slotIcons)
        {
            slots.gameObject.SetActive(false);
        }

        //�g�p����{�^�����\��
        useButton.gameObject.SetActive(false);

        useButton.onClick.AddListener(() => OnClickUseItem());

        //�C���x���g���A�C�R����\��
        inventoryIcon.SetActive(true);

        RefreshUI();
    }

    private void Update()
    {
        if (currentItems.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //�e�C���x���g��UI���\��
                mainItemIcon.SetActive(true);
                itemNameObject.SetActive(true);
                itemDescriptionObject.SetActive(true);

                itemIconImage.gameObject.SetActive(true);

                //�A�C�e���X���b�g�����ׂĔ�\��
                foreach (var button in slotButtons)
                {
                    button.gameObject.SetActive(true);
                }

                //�X���b�g�A�C�R������\��
                foreach (var slots in slotIcons)
                {
                    slots.gameObject.SetActive(true);
                }

                //�g�p����{�^�����\��
                useButton.gameObject.SetActive(true);
                
                //�C���x���g���A�C�R����\��
                inventoryIcon.SetActive(false);

                RefreshUI();

            }
        }
    }

    public void RefreshUI()
    {
        currentItems = InventoryManager.Instance.GetInventoryItems();

        for (int i = 0; i < slotButtons.Count; i++)
        {
            if (i < currentItems.Count)
            {
                ItemStatus item = currentItems[i];
                slotIcons[i].sprite = item.Icon;
                slotIcons[i].color = Color.white;

                int index = i; // �N���[�W���΍�
                slotButtons[i].onClick.RemoveAllListeners(); // �Â��C�x���g���N���A
                slotButtons[i].onClick.AddListener(() => OnClickSlot(currentItems[index]));
            }
            else
            {
                slotIcons[i].sprite = null;
                slotIcons[i].color = new Color(1, 1, 1, 0); // �����ɂ���
                slotButtons[i].onClick.RemoveAllListeners();
            }
        }

        ShowItemDetail(null); // �ڍ׃N���A
    }

    private void OnClickSlot(ItemStatus item)
    {
        selectedItem = item;
        ShowItemDetail(item);
    }

    private void ShowItemDetail(ItemStatus item)
    {
        if (item == null)
        {
            itemNameText.text = "";
            itemIconImage.sprite = null;
            itemDescriptionText.text = "";
            itemIconImage.color = new Color(1, 1, 1, 0);
            return;
        }

        itemNameText.text = item.ItemName;
        itemIconImage.sprite = item.Icon;
        itemDescriptionText.text = item.description;
        itemIconImage.color = Color.white;
    }

    private void OnClickUseItem()
    {
        if (selectedItem == null)
        {
            Debug.Log("�g�p����A�C�e�����I������Ă��܂���");
            return;
        }

        Debug.Log($"�A�C�e�� {selectedItem.ItemName} ���g�p���܂���");
        InventoryManager.Instance.RemoveItem(selectedItem);
        selectedItem = null;
        RefreshUI();
    }

}
