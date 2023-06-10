using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReduceItemQuantityInBP : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase;

    [SerializeField] private GameObject itemInBP;
    [SerializeField] private GameObject itemButton;

    private ItemData myItemData;

    private TextMeshProUGUI itemQTYText;
    private int itemQuantity = 0;

    private GameObject information;
    private TextMeshProUGUI informationText;

    public bool switch1 = false;
    public bool switch2 = false;
    public bool switch3 = false;
    public bool switch4 = false;

    // Start is called before the first frame update
    void Start()
    {
        List<ItemData> myItemDataList = itemDataBase.GetItemDataList();

        //　対応するアイテムデータを取得
        myItemData = itemDataBase.GetItemData(itemInBP.name);
        //　アイテムの個数の表示UIを取得
        itemQTYText = itemInBP.GetComponentInChildren<TextMeshProUGUI>();
        //　アイテム情報の表示UIを取得
        information = GameObject.Find("ItemSelectUI/Panel/Information");
        informationText = information.GetComponentInChildren<TextMeshProUGUI>(); 
        if (itemButton.name == "Item1")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item1");
            switch1 = true;

        }
        else if (itemButton.name == "Item2")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item2");
            switch2 = true;
        }
        else if (itemButton.name == "Item3")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item3");
            switch3 = true;
        }
        else if (itemButton.name == "Item4")
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
    }

    public void OnClick()
    {        
        //　アイテムの個数を取得し、ー１する
        itemQuantity = myItemData.GetItemQuantity();
        itemQuantity--;
        //Debug.Log(itemQuantity.ToString());
        //　個数の変更を記録
        myItemData.ChangeItemQuantity(itemQuantity);
        //　アイテムとその個数を表示
       
        if (switch1 == true)
        {
            PutItemInBackPack.quantity1 = itemQuantity;
            
        }
        if (switch2 == true)
        {
            PutItemInBackPack.quantity2 = itemQuantity;
            
        }
        if (switch3 == true)
        {
            PutItemInBackPack.quantity3 = itemQuantity;
            
        }
        if (switch4 == true)
        {
            PutItemInBackPack.quantity4 = itemQuantity;
            
        }
        if (itemQuantity == 0)
        {
            itemInBP.SetActive(false);
            return;
        }
        itemQTYText = itemInBP.GetComponentInChildren<TextMeshProUGUI>();
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
       // Debug.Log("MouseExit");
    }
}
