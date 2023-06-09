using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase;

    [SerializeField] private GameObject itemButton;

    private ItemData myItemData;

    private TextMeshProUGUI itemQTYText;
    int itemQuantity = 3;

    private GameObject information;
    private TextMeshProUGUI informationText;

    [SerializeField] bool isShoesUse = false;

    private GameObject UseItemsUI;
    private TextMeshProUGUI panelYText;
    UseItems useItems;
   
    public static bool Item2 = true;
    private GameObject itemInBP;
    public int changedItem;




    void Start()
    {

        //　アイテムデータリストを取得
        List<ItemData> myItemDataList = itemDataBase.GetItemDataList();
        //　対応するアイテムデータを取得
        myItemData = itemDataBase.GetItemData(itemButton.name);
        //　アイテムの個数の表示UIを取得
        itemQTYText = itemButton.GetComponentInChildren<TextMeshProUGUI>();


        //　アイテム情報の表示UIを取得
        information = GameObject.Find("InventoryUI/Panel/Information");
        informationText = information.GetComponentInChildren<TextMeshProUGUI>();


        //もしシューズか回復薬なら、アイテム使用の準備をする
        if (itemButton.name == "Item2" || itemButton.name == "Item3")
        {
            UseItemsUI = GameObject.Find("InventoryUI/Panel/UseItemsUI");
            useItems = UseItemsUI.GetComponent<UseItems>();
            panelYText = GameObject.Find("InventoryUI/Panel/PanelY").GetComponentInChildren<TextMeshProUGUI>();


        }
    }
    private void Update()
    {


        //　どのアイテムボタンか判別
        if (itemButton.name == "Item1")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("InventoryUI/Panel/Main/Item1");
            //　対応するアイテムデータを取得
            myItemData = itemDataBase.GetItemData(itemInBP.name);
            itemQuantity = PutItemInBackPack.quantity1;
            itemQTYText.text = itemQuantity.ToString();
            if (itemQuantity == 0)
            {
                itemInBP.SetActive(false);
                return;
            }
        }
        else if (itemButton.name == "Item2")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("InventoryUI/Panel/Main/Item2");
            //　対応するアイテムデータを取得
            myItemData = itemDataBase.GetItemData(itemInBP.name);
            itemQuantity = PutItemInBackPack.quantity2;
            itemQTYText.text = itemQuantity.ToString();
            if (itemQuantity == 0)
            {
                itemInBP.SetActive(false);
                return;
            }
        }
        else if (itemButton.name == "Item3")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("InventoryUI/Panel/Main/Item3");
            //　対応するアイテムデータを取得
            myItemData = itemDataBase.GetItemData(itemInBP.name);
            itemQuantity = PutItemInBackPack.quantity3;
            itemQTYText.text = itemQuantity.ToString();
            if (itemQuantity == 0)
            {
                itemInBP.SetActive(false);
                return;
            }
        }
        else if (itemButton.name == "Item4")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("InventoryUI/Panel/Main/Item4");
            //　対応するアイテムデータを取得
            myItemData = itemDataBase.GetItemData(itemInBP.name);
            itemQuantity = PutItemInBackPack.quantity4;
            itemQTYText.text = itemQuantity.ToString();
            if (itemQuantity == 0)
            {
                itemInBP.SetActive(false);
                return;
            }
        }
        else if (itemButton.name == "Item5")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("InventoryUI/Panel/Main/Item5");

        }
        else if (itemButton.name == "Item6")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("InventoryUI/Panel/Main/Item6");

        }
        else if (itemButton.name == "Item7")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("InventoryUI/Panel/Main/Item7");

        }
        else
        {
            Debug.Log("Error");
            return;
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
            Item2 = true;
            //Question という名前のオブジェクトを取得
            GameObject objb = GameObject.Find("BackButton");
            objb.gameObject.SetActive(false);
        }

 

        if (itemButton.name == "Item3")
        {
            StartCoroutine(ShowMsg());
            panelYText.text = "体力が10回復！";
            Item2 = false;
            //Question という名前のオブジェクトを取得
            GameObject objb = GameObject.Find("BackButton");
            objb.gameObject.SetActive(false);
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
    
}

