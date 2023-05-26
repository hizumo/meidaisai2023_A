using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PutItemInBackPack : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase;

    [SerializeField] private GameObject itemButton;
    public GameObject itemInBP;
    public TextMeshProUGUI itemQTYText;
    private int itemQuantity = 0;

    void Start()
    {
        List<ItemData> myItemDataList = itemDataBase.GetItemDataList();
    }
    //　ボタンを押したときの処理
    public void OnClick()
    {
        //　どのアイテムボタンか判別
        if (itemButton.name == "ItemR1")
        {
            Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item1");
            //itemNumber = 1;
        }
        else if (itemButton.name == "ItemR2")
        {
            Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item2");
            //itemNumber = 2;
        }
        else if (itemButton.name == "ItemR3")
        {
            Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item3");
            //itemNumber = 3;
        }
        else
        {
            Debug.Log("Error");
            return;
        }

        //　対応するアイテムデータを取得
        ItemData myItemData = itemDataBase.GetItemData(itemInBP.name);
        //　アイテムの個数を取得し、＋１する
        itemQuantity = myItemData.GetItemQuantity();
        itemQuantity++;
        Debug.Log(itemQuantity.ToString());
        //　個数の変更を記録
        myItemData.ChangeItemQuantity(itemQuantity);
        //　アイテムとその個数を表示
        itemInBP.SetActive(true);
        itemQTYText = itemInBP.GetComponentInChildren<TextMeshProUGUI>();
        itemQTYText.text = itemQuantity.ToString();
    }
}
