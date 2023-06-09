//Not using
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProcessingSlot : MonoBehaviour
{
    // アイテム情報を表示するテキストUI
    private Text informationText;
    //　アイテム名を表示するテキストUIプレハブ
    [SerializeField] private GameObject itemSlotTitleUI;
    //　アイテム名を表示するテキストUIをインスタンス化したものを入れておく
    private GameObject itemSlotTitleUIInstance;
    //　自身のアイテムデータを入れておく
    public ItemData myItemData;

    //public GameObject Image;

    //　スロットが非アクティブになったら削除
    private void OnDisable()
    {
        if(itemSlotTitleUIInstance != null)
        {
            Destroy(itemSlotTitleUIInstance);
        }
        Destroy(gameObject);
    }  

    //　アイテムのデータをセット
    public void SetItemData(ItemData itemData)
    {
        myItemData = itemData;
        //　アイテムのスプライトを設定
        //transform.GetChild(0).GetComponent<Image>().sprite = myItemData.GetItemSprite();
    }

    void Start()
    {
        //　アイテムスロットの親の親からInformationゲームオブジェクトを探しTextコンポーネントを取得する
        informationText = transform.parent.parent.Find("Information").GetChild(0).GetComponent<Text>();
    }

    public void MouseOver()
    {
        if (itemSlotTitleUIInstance != null) 
        {
            Destroy(itemSlotTitleUIInstance);
        }
        //　情報表示テキストに自身のアイテム情報を表示
        informationText.text = myItemData.GetItemInformation();
        //　アイテム名を表示するUIを位置を調整してインスタンス化
        itemSlotTitleUIInstance = Instantiate<GameObject>(itemSlotTitleUI, new Vector2(transform.position.x - 25f, transform.position.y + 25f), Quaternion.identity, transform.parent.parent);
        // アイテム表示テキストを取得
        var itemSlotTitleText = itemSlotTitleUIInstance.GetComponentInChildren<Text>();
        //　アイテム表示テキストに自身のアイテムを表示
        itemSlotTitleText.text = myItemData.GetItemName();
        
    }

    public void MouseExit()
    {
        //　マウスポインタがアイテムスロットを出たらアイテム表示UIを削除
        if(itemSlotTitleUIInstance != null)
        {
            informationText.text = "";
            Destroy(itemSlotTitleUIInstance);
        }
    }
}
