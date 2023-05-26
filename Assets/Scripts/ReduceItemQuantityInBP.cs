using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ReduceItemQuantityInBP : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase;

    [SerializeField] private GameObject itemInBP;
    public TextMeshProUGUI itemQTYText;
    private int itemQuantity = 0;

    // Start is called before the first frame update
    void Start()
    {
        List<ItemData> myItemDataList = itemDataBase.GetItemDataList();
    }

    public void OnClick()
    {
        //�@�Ή�����A�C�e���f�[�^���擾
        ItemData myItemData = itemDataBase.GetItemData(itemInBP.name);
        //�@�A�C�e���̌����擾���A�[�P����
        itemQuantity = myItemData.GetItemQuantity();
        itemQuantity--;
        Debug.Log(itemQuantity.ToString());
        //�@���̕ύX���L�^
        myItemData.ChangeItemQuantity(itemQuantity);
        //�@�A�C�e���Ƃ��̌���\��
        if(itemQuantity == 0) 
        {
            itemInBP.SetActive(false);
            return;
        }
        itemQTYText = itemInBP.GetComponentInChildren<TextMeshProUGUI>();
        itemQTYText.text = itemQuantity.ToString();
    }
}
