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
        RayGun
    }

   //　アイテムデータのリスト
    public List<ItemData> itemDataList = new List<ItemData>();

    void Awake()
    {
        //　アイテムの全情報を生成
        itemDataList.Add(new ItemData("Item1", ItemType.PickAxe, "<size=72><b>ツルハシ</b><size=60>：鉱石の採掘時の消費体力を軽減する。", 0)); //Resources.Load("Item1") as Sprite, "Item1", ItemType.PickAxe "１つ目のアイテムです", 0));
        itemDataList.Add(new ItemData("Item2", ItemType.AccelShoes, "<size=72><b>シューズ</b><size=60>：一定時間移動速度がアップ。", 0));//Resources.Load("Item2") as Sprite, "Item2", ItemType.SpeedShoes, "２つ目のアイテムです", 0));
        itemDataList.Add(new ItemData("Item3", ItemType.HealingItem, "<size=72><b>回復薬</b><size=60>：体力を一定値回復する。", 0));//Resources.Load("Item3") as Sprite, "Item3", ItemType.HealingItem, "３つ目のアイテムです", 0));    
        itemDataList.Add(new ItemData("Item4", ItemType.RayGun, "<size=72><b>光線銃</b><size=60>：未定", 0));
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
