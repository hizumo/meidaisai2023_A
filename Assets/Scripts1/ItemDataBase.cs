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
        itemDataList.Add(new ItemData(Resources.Load("Item1", typeof(Sprite)) as Sprite, "アイテム１", ItemType.Item1, "１つ目のアイテムです"));
        itemDataList.Add(new ItemData(Resources.Load("Item2", typeof(Sprite)) as Sprite, "アイテム２", ItemType.Item1, "２つ目のアイテムです"));
        itemDataList.Add(new ItemData(Resources.Load("Item3", typeof(Sprite)) as Sprite, "アイテム３", ItemType.Item1, "３つ目のアイテムです"));
    }

    //　全アイテムデータを返す
    public List<ItemData> GetItemDataList()
    {
        return itemDataList;
    }

    //　個々のアイテムデータを返す
    public ItemData GetItemData(string itemName)
    {
        foreach (var item in itemDataList) 
        {
            if(item.GetItemName() ==  itemName)
            {
                return item;
            }
        }
        return null;   }
}
