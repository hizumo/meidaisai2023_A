using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PutItemInBackPack : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase;

    [SerializeField] private GameObject itemButton;
    public GameObject itemInBP;
    public TextMeshProUGUI itemQTYText;
    private int itemQuantity = 0;

    void Start()
    {
        List<ItemData> myItemDataList = itemDataBase.GetItemDataList();
    }
    //�@�{�^�����������Ƃ��̏���
    public void OnClick()
    {
        //�@�ǂ̃A�C�e���{�^��������
        if (itemButton.name == "ItemR1")
        {
            Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item1");
            //itemNumber = 1;
        }
        else if (itemButton.name == "ItemR2")
        {
            Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item2");
            //itemNumber = 2;
        }
        else if (itemButton.name == "ItemR3")
        {
            Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item3");
            //itemNumber = 3;
        }
        else
        {
            Debug.Log("Error");
            return;
        }

        //�@�Ή�����A�C�e���f�[�^���擾
        ItemData myItemData = itemDataBase.GetItemData(itemInBP.name);
        //�@�A�C�e���̌����擾���A�{�P����
        itemQuantity = myItemData.GetItemQuantity();
        itemQuantity++;
        Debug.Log(itemQuantity.ToString());
        //�@���̕ύX���L�^
        myItemData.ChangeItemQuantity(itemQuantity);
        //�@�A�C�e���Ƃ��̌���\��
        itemInBP.SetActive(true);
        itemQTYText = itemInBP.GetComponentInChildren<TextMeshProUGUI>();
        itemQTYText.text = itemQuantity.ToString();
    }
}
