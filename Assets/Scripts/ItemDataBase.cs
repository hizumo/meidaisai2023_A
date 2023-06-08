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
        Ore1,
        Ore2,
        Ore3
    }

   //　アイテムデータのリスト
    public List<ItemData> itemDataList = new List<ItemData>();

    void Awake()
    {
        //　アイテムの全情報を生成
        itemDataList.Add(new ItemData("Item1", ItemType.PickAxe, "<size=84><b>ツルハシ</b>\n<size=60>採掘時の消費体力を軽減する。", 0, 1.1f)); //Resources.Load("Item1") as Sprite, "Item1", ItemType.PickAxe "１つ目のアイテムです", 0));
        itemDataList.Add(new ItemData("Item2", ItemType.AccelShoes, "<size=84><b>シューズ</b>\n<size=60>一定時間移動速度を上げる。", 0, 0.5f));//Resources.Load("Item2") as Sprite, "Item2", ItemType.SpeedShoes, "２つ目のアイテムです", 0));
        itemDataList.Add(new ItemData("Item3", ItemType.HealingItem, "<size=84><b>回復薬</b>\n<size=60>体力を一定値回復する。", 0, 0.4f));//Resources.Load("Item3") as Sprite, "Item3", ItemType.HealingItem, "３つ目のアイテムです", 0));    
        itemDataList.Add(new ItemData("Item4", ItemType.RayGun, "<size=84><b>光線銃</b>\n<size=60>敵性存在を撃退する。", 0, 0.7f));
        itemDataList.Add(new ItemData("Item5", ItemType.Ore1, "<size=84><b>黒い鉱石</b>\n<size=60>持つとずっしりと重たい。", 0, 1.6f));
        itemDataList.Add(new ItemData("Item6", ItemType.Ore2, "<size=84><b>輝く鉱石</b>\n<size=60>軽くて簡単に持てる。", 0, 0.3f));
        itemDataList.Add(new ItemData("Item7", ItemType.Ore3, "<size=84><b>トゲトゲの鉱石</b>\n<size=60>採掘するのに体力を多く使う。", 0, 1.2f));
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
