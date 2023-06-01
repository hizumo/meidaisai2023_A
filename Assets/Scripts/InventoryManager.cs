using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase;

    [SerializeField] private GameObject itemButton;
    //private GameObject itemInBP;

    private ItemData myItemData;

    private TextMeshProUGUI itemQTYText;
    private int itemQuantity; // = 0;

    private GameObject information;
    private TextMeshProUGUI informationText;

    void Start()
    {
        //�@�A�C�e���f�[�^���X�g���擾
        List<ItemData> myItemDataList = itemDataBase.GetItemDataList();
        //�@�ǂ̃A�C�e���{�^��������
        /*if (itemButton.name == "ItemR1")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item1");
        }
        else if (itemButton.name == "ItemR2")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item2");
        }
        else if (itemButton.name == "ItemR3")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item3");
        }
        else if (itemButton.name == "ItemR4")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item4");
        }
        else
        {
            Debug.Log("Error");
            return;
        }*/
        //�@�Ή�����A�C�e���f�[�^���擾
        myItemData = itemDataBase.GetItemData(itemButton.name);
        //if(myItemData != null) {Debug.Log("Ready�I");}
        //�@�A�C�e���̌��̕\��UI���擾
        itemQTYText = itemButton.GetComponentInChildren<TextMeshProUGUI>();
        //�@�A�C�e�����̕\��UI���擾
        information = GameObject.Find("InventoryUI/Panel/Information");
        informationText = information.GetComponentInChildren<TextMeshProUGUI>();
        if(informationText != null)
        {
            Debug.Log("Ready�I");
        }
        itemQuantity = myItemData.GetItemQuantity();
    }
    //�@�{�^�����������Ƃ��̏���
    public void OnClick()
    {
        /*//�@�A�C�e���̌����擾���A�{�P����
        itemQuantity = myItemData.GetItemQuantity();
        itemQuantity++;
        //Debug.Log(itemQuantity.ToString());
        //�@���̕ύX���L�^
        myItemData.ChangeItemQuantity(itemQuantity);
        //�@�A�C�e���Ƃ��̌���\��
        if (itemQuantity > 0)
        {
            itemInBP.SetActive(true);
        }
        itemQTYText.text = itemQuantity.ToString();*/
        Debug.Log("The button was pushed�I");
    }

    public void MouseOver()
    {
        informationText.text = myItemData.GetItemInformation();
        //Debug.Log("MouseOver");
    }
    public void MouseExit()
    {
        informationText.text = "";
        //Debug.Log("MouseExit");
    }
}

