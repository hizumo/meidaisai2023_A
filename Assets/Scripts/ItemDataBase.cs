using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{

    //　アイテムの種類
    public enum ItemType
    {
        Item1,
        Item2,
        Item3
    }

   //　アイテムデータのリスト
    public List<ItemData> itemDataList = new List<ItemData>();

    void Awake()
    {
        //　アイテムの全情報を生成
        itemDataList.Add(new ItemData("Item1", ItemType.Item1, "１つ目のアイテムです", 0)); //Resources.Load("Item1") as Sprite, "Item1", ItemType.Item1, "１つ目のアイテムです", 0));
        itemDataList.Add(new ItemData("Item2", ItemType.Item2, "２つ目のアイテムです", 0));//Resources.Load("Item2") as Sprite, "Item2", ItemType.Item2, "２つ目のアイテムです", 0));
        itemDataList.Add(new ItemData("Item3", ItemType.Item3, "３つ目のアイテムです", 0));//Resources.Load("Item3") as Sprite, "Item3", ItemType.Item3, "３つ目のアイテムです", 0));    
    }

    //　アイテムデータリストを取得
    public List<ItemData> GetItemDataList()
    {
        return itemDataList;
    }
    //　個々のアイテムデータを返す
    public ItemData GetItemData(string itemName)
    {
        foreach (var item in itemDataList)
        {
            if (item.GetItemName() == itemName)
            {
                return item;
            }
        }
        return null;
    }
}
