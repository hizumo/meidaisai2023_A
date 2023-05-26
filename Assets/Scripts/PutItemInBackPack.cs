using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PutItemInBackPack : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase;

    [SerializeField] private GameObject itemButton;
    private GameObject itemInBP;　　

    private ItemData myItemData;

    private TextMeshProUGUI itemQTYText;
    private int itemQuantity = 0;

    private GameObject information;
    private TextMeshProUGUI informationText;

    void Start()
    {
        //　アイテムデータリストを取得
        List<ItemData> myItemDataList = itemDataBase.GetItemDataList();
        //　どのアイテムボタンか判別
        if (itemButton.name == "ItemR1")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item1");
        }
        else if (itemButton.name == "ItemR2")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item2");
        }
        else if (itemButton.name == "ItemR3")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item3");
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
