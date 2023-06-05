using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{

    //　アイテムの種類
    public enum ItemType
    {
        PickAxe,
        AccelShoes,
        HealingItem,
        RayGun,
        Ore
    }

   //　アイテムデータのリスト
    public List<ItemData> itemDataList = new List<ItemData>();

    void Awake()
    {
        //　アイテムの全情報を生成
        itemDataList.Add(new ItemData("Item1", ItemType.PickAxe, "<size=84><b>ツルハシ</b>\n<size=60>採掘時の消費体力を軽減する。", 0, 1.1f)); //Resources.Load("Item1") as Sprite, "Item1", ItemType.PickAxe "１つ目のアイテムです", 0));
        itemDataList.Add(new ItemData("Item2", ItemType.AccelShoes, "<size=84><b>シューズ</b>\n<size=60>一定時間移動速度を上げる。", 0, 0.5f));//Resources.Load("Item2") as Sprite, "Item2", ItemType.SpeedShoes, "２つ目のアイテムです", 0));
        itemDataList.Add(new ItemData("Item3", ItemType.HealingItem, "<size=84><b>回復薬</b>\n<size=60>体力を一定値回復する。", 0, 0.4f));//Resources.Load("Item3") as Sprite, "Item3", ItemType.HealingItem, "３つ目のアイテムです", 0));    
        itemDataList.Add(new ItemData("Item4", ItemType.RayGun, "<size=84><b>光線銃</b>\n<size=60>敵を撃退する。", 0, 0.7f));
        itemDataList.Add(new ItemData("Item5", ItemType.Ore, "<size=84><b>謎の鉱石</b>\n<size=60>見たことのない鉱石。ずっしりと重たい。", 0, 1.5f));
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
