using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// インベントリのUIをコントロールするスクリプト
/// </summary>
public class InventoryUIController : MonoBehaviour
{
    [SerializeField]
    [Header("スロットの親オブジェクト")]
    private List<Button> slotButtons;

    [SerializeField]
    [Header("スロット内のアイコンImage")]
    private List<Image> slotIcons;

    [Header("詳細表示UI")]
    public TMP_Text itemNameText;
    public Image itemIconImage;
    public TMP_Text itemDescriptionText;

    [Header("使用ボタン")]
    public Button useButton;

    [Header("右側のUI")]

    [SerializeField]
    [Tooltip("アイテム名を表示するタグ")]
    private GameObject itemNameObject;

    [SerializeField]
    [Tooltip("親元アイテムアイコン")]
    private GameObject mainItemIcon;

    [SerializeField]
    [Tooltip("イメージアイテムアイコン")]
    private Image itemIcon;

    [SerializeField]
    [Tooltip("アイテム情報欄")]
    private GameObject itemDescriptionObject;

    [Header("インベントリを開くアイコン")]

    [SerializeField]
    [Tooltip("インベントリアイコン")]
    private GameObject inventoryIcon;


    private ItemStatus selectedItem = null;

    [SerializeField]
    private List<ItemStatus> currentItems;



    // Start is called before the first frame update
    void Start()
    {
        //各インベントリUIを非表示
        mainItemIcon.SetActive(false);
        itemNameObject.SetActive(false);
        itemDescriptionObject.SetActive(false);

        itemIconImage.gameObject.SetActive(false);

        //アイテムスロットをすべて非表示
        foreach (var button in slotButtons)
        {
            button.gameObject.SetActive(false);
        }

        //スロットアイコンも非表示
        foreach(var slots in slotIcons)
        {
            slots.gameObject.SetActive(false);
        }

        //使用するボタンを非表示
        useButton.gameObject.SetActive(false);

        useButton.onClick.AddListener(() => OnClickUseItem());

        //インベントリアイコンを表示
        inventoryIcon.SetActive(true);

        RefreshUI();
    }

    private void Update()
    {
        if (currentItems.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //各インベントリUIを非表示
                mainItemIcon.SetActive(true);
                itemNameObject.SetActive(true);
                itemDescriptionObject.SetActive(true);

                itemIconImage.gameObject.SetActive(true);

                //アイテムスロットをすべて非表示
                foreach (var button in slotButtons)
                {
                    button.gameObject.SetActive(true);
                }

                //スロットアイコンも非表示
                foreach (var slots in slotIcons)
                {
                    slots.gameObject.SetActive(true);
                }

                //使用するボタンを非表示
                useButton.gameObject.SetActive(true);
                
                //インベントリアイコンを表示
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

                int index = i; // クロージャ対策
                slotButtons[i].onClick.RemoveAllListeners(); // 古いイベントをクリア
                slotButtons[i].onClick.AddListener(() => OnClickSlot(currentItems[index]));
            }
            else
            {
                slotIcons[i].sprite = null;
                slotIcons[i].color = new Color(1, 1, 1, 0); // 透明にする
                slotButtons[i].onClick.RemoveAllListeners();
            }
        }

        ShowItemDetail(null); // 詳細クリア
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
            Debug.Log("使用するアイテムが選択されていません");
            return;
        }

        Debug.Log($"アイテム {selectedItem.ItemName} を使用しました");
        InventoryManager.Instance.RemoveItem(selectedItem);
        selectedItem = null;
        RefreshUI();
    }

}
