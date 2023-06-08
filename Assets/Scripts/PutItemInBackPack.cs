using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Tilemaps;

public class PutItemInBackPack : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase;

    [SerializeField] private GameObject itemButton;
    private GameObject itemInBP;

    private ItemData myItemData;
    

    private TextMeshProUGUI itemQTYText;
    public int itemQuantity = 0;

    private GameObject information;
    private TextMeshProUGUI informationText;
    public static ItemData changedata;

    public bool switch1 = false;
    public bool switch2 = false;
    public bool switch3 = false;
    public bool switch4 = false;

    public static int quantity1 = 0;
    public static int quantity2 = 0;
    public static int quantity3 = 0;
    public static int quantity4 = 0;

    void Start()
    {
        //　アイテムデータリストを取得
        List<ItemData> myItemDataList = itemDataBase.GetItemDataList();
        //　どのアイテムボタンか判別
        if (itemButton.name == "ItemR1")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item1");
            switch1 = true;
        }
        else if (itemButton.name == "ItemR2")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item2");
            switch2 = true;
        }
        else if (itemButton.name == "ItemR3")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item3");
            switch3 = true;
        }
        else if (itemButton.name == "ItemR4")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item4");
            switch4 = true;
        }
        else
        {
            Debug.Log("Error");
            return;
        }
        //　対応するアイテムデータを取得
        myItemData = itemDataBase.GetItemData(itemInBP.name);
        //　アイテムの個数の表示UIを取得
        itemQTYText = itemInBP.GetComponentInChildren<TextMeshProUGUI>();
        //　アイテム情報の表示UIを取得
        information = GameObject.Find("ItemSelectUI/Panel/Information");
        informationText = information.GetComponentInChildren<TextMeshProUGUI>();
        
    }
    //　ボタンを押したときの処理
    public void OnClick()
    {
        List<ItemData> myItemDataList = itemDataBase.GetItemDataList();
        //　アイテムの個数を取得し、＋１する
        itemQuantity = myItemData.GetItemQuantity();
        itemQuantity++;
        //Debug.Log(itemQuantity.ToString());
        //　個数の変更を記録
        myItemData.ChangeItemQuantity(itemQuantity);
        //　アイテムとその個数を表示
        if(itemQuantity > 0)
        {
            itemInBP.SetActive(true);
        }
        itemQTYText.text = itemQuantity.ToString();
        // 選択したアイテムをセット
        SelectedItems.SetSelectedItem(myItemData);

        if (switch1 == true)
        {
            quantity1 = itemQuantity;
        }
        if (switch2 == true)
        {
            quantity2 = itemQuantity;
        }
        if (switch3 == true)
        {
            quantity3 = itemQuantity;
        }
        if (switch4 == true)
        {
            quantity4 = itemQuantity;
        }
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
}
