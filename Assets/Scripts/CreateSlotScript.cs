using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class CreateSlotScript : MonoBehaviour
{
    //　アイテム情報のスロットプレハブ
    [SerializeField] private GameObject itemSlot;
    //　主人公のステータス
    //[SerializeField] MyStatus myStatus;
    //　アイテムデータベース
    [SerializeField] private ItemDataBase itemDataBase;

    //　アクティブになった時
    void Start()
    {
        //　アイテムデータベースに登録されているアイテム用のスロットを全生成
        CreateSlot(itemDataBase.GetItemDataList());
    }

    //　アイテムスロットの生成
    public void CreateSlot(List<ItemData> itemList)
    {
        int i = 0;
        foreach (var item in itemList) 
        {
            //　スロットのインスタンス化
            var instanceSlot = Instantiate<GameObject>(itemSlot, transform);
            //　スロットゲームオブジェクトの名前を設定
            instanceSlot.name = "ItemSlot" + i++;
            //　Scaleを設定しないと0になるので設定
            instanceSlot.transform.localScale = new Vector3 (1f, 1f, 1f);
            //　アイテム情報をスロットのProcessingSlotに設定する
            instanceSlot.GetComponent<ProcessingSlot>().SetItemData(item);
        }
    }
}
