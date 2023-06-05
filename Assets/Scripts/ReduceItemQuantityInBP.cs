using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReduceItemQuantityInBP : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase;

    [SerializeField] private GameObject itemInBP;

    private ItemData myItemData;

    private TextMeshProUGUI itemQTYText;
    private int itemQuantity = 0;

    private GameObject information;
    private TextMeshProUGUI informationText;


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
        if(itemQuantity == 0) 
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
