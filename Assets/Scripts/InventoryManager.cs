using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase;

    [SerializeField] private GameObject itemButton;

    private ItemData myItemData;

    private TextMeshProUGUI itemQTYText;
    private int itemQuantity = 3;

    private GameObject information;
    private TextMeshProUGUI informationText;

    [SerializeField] bool isShoesUse = false;

    private GameObject UseItemsUI;
    private TextMeshProUGUI panelYText;
    UseItems useItems;

    void Start()
    {
        //　アイテムデータリストを取得
        List<ItemData> myItemDataList = itemDataBase.GetItemDataList();
       
        //　対応するアイテムデータを取得
        myItemData = itemDataBase.GetItemData(itemButton.name);
        //　アイテムの個数の表示UIを取得
        itemQTYText = itemButton.GetComponentInChildren<TextMeshProUGUI>();
        itemQTYText.text = itemQuantity.ToString();
        //　アイテム情報の表示UIを取得
        information = GameObject.Find("InventoryUI/Panel/Information");
        informationText = information.GetComponentInChildren<TextMeshProUGUI>();
        //もしシューズか回復薬なら、アイテム使用の準備をする
        if(itemButton.name == "Item2" || itemButton.name == "Item3")
        {
            UseItemsUI = GameObject.Find("InventoryUI/Panel/UseItemsUI");
            useItems = UseItemsUI.GetComponent<UseItems>();
            panelYText = GameObject.Find("InventoryUI/Panel/PanelY").GetComponentInChildren<TextMeshProUGUI>();
        }
       
    }
    //　ボタンを押したときの処理
    public void OnClick()
    {
        /*//　アイテムの個数を取得し、＋１する
        itemQuantity = myItemData.GetItemQuantity();
        itemQuantity++;
        //Debug.Log(itemQuantity.ToString());
        //　個数の変更を記録
        myItemData.ChangeItemQuantity(itemQuantity);
        //　アイテムとその個数を表示
        if (itemQuantity > 0)
        {
            itemInBP.SetActive(true);
        }*/
        if(itemButton.name == "Item2")
        {
            StartCoroutine(ShowMsg());
            panelYText.text = "移動速度アップ！";
        }

        if (itemButton.name == "Item3")
        {
            StartCoroutine(ShowMsg());
            panelYText.text = "体力が〇〇回復！";
        }
        /*if (itemButton.name == "Item3") // || itemButton.name == "Item3")
        {
            UseItemsUI.SetActive(true);
            UseItems useItems = UseItemsUI.GetComponentInChildren<UseItems>();
            if (useItems.isItemUsed == true)
            {
                itemQuantity--;
                
                useItems.isItemUsed = false;
                Debug.Log("シューズを使用");
            }
        }*/
    }

    public void MouseOver()
    {
        informationText.text = myItemData.GetItemInformation();
        //Debug.Log("MouseOver");
    }
    public void MouseExit()
    {
        informationText.text = "";
        //Debug.Log("MouseExit");
    }
    IEnumerator ShowMsg()
    {
        UseItemsUI.SetActive(true);
        useItems.isButtonClicked = false;
        yield return new WaitUntil(() => useItems.isButtonClicked == true);
        if (useItems.isItemUsed == true)
        {
            itemQuantity--;
            isShoesUse = true;
            useItems.isItemUsed = false;
            //Debug.Log("used");
        }
        //else{Debug.Log("not used");}

        if (itemQuantity == 0)
        {
            itemButton.SetActive(false);
        }
        //itemQuantity = myItemData.GetItemQuantity();
        itemQTYText.text = itemQuantity.ToString();
        //Debug.Log(itemQuantity.ToString());
    }
    /*float totalWeight = 0f;
    int itemQuantityS = 0;
    float itemWeight = 0f;
    float moveSpeed;
    [SerializeField] int defaultSpeed = 5;
    [SerializeField] bool isShoesUsing;
    public void AdjustSpeed(List<ItemData> itemDataList)
    {
        foreach (ItemData itemData in itemDataList)
        {
            itemQuantityS = itemData.GetItemQuantity();
            itemWeight = itemData.GetItemWeight();
            totalWeight += itemQuantityS * itemWeight;
        }
        moveSpeed = defaultSpeed + 2 * Convert.ToInt32(isShoesUsing) - totalWeight;
    }*/
}

