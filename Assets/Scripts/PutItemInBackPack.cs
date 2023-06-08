using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Tilemaps;

public class PutItemInBackPack : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase;

    [SerializeField] private GameObject itemButton;
    private GameObject itemInBP;

    private ItemData myItemData;
    

    private TextMeshProUGUI itemQTYText;
    public int itemQuantity = 0;

    private GameObject information;
    private TextMeshProUGUI informationText;
    public static ItemData changedata;

    public bool switch1 = false;
    public bool switch2 = false;
    public bool switch3 = false;
    public bool switch4 = false;

    public static int quantity1 = 0;
    public static int quantity2 = 0;
    public static int quantity3 = 0;
    public static int quantity4 = 0;

    void Start()
    {
        //�@�A�C�e���f�[�^���X�g���擾
        List<ItemData> myItemDataList = itemDataBase.GetItemDataList();
        //�@�ǂ̃A�C�e���{�^��������
        if (itemButton.name == "ItemR1")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item1");
            switch1 = true;
        }
        else if (itemButton.name == "ItemR2")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item2");
            switch2 = true;
        }
        else if (itemButton.name == "ItemR3")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item3");
            switch3 = true;
        }
        else if (itemButton.name == "ItemR4")
        {
            //Debug.Log(itemButton.name);
            itemInBP = GameObject.Find("ItemSelectUI/Panel/BackPackMain/Item4");
            switch4 = true;
        }
        else
        {
            Debug.Log("Error");
            return;
        }
        //�@�Ή�����A�C�e���f�[�^���擾
        myItemData = itemDataBase.GetItemData(itemInBP.name);
        //�@�A�C�e���̌��̕\��UI���擾
        itemQTYText = itemInBP.GetComponentInChildren<TextMeshProUGUI>();
        //�@�A�C�e�����̕\��UI���擾
        information = GameObject.Find("ItemSelectUI/Panel/Information");
        informationText = information.GetComponentInChildren<TextMeshProUGUI>();
        
    }
    //�@�{�^�����������Ƃ��̏���
    public void OnClick()
    {
        List<ItemData> myItemDataList = itemDataBase.GetItemDataList();
        //�@�A�C�e���̌����擾���A�{�P����
        itemQuantity = myItemData.GetItemQuantity();
        itemQuantity++;
        //Debug.Log(itemQuantity.ToString());
        //�@���̕ύX���L�^
        myItemData.ChangeItemQuantity(itemQuantity);
        //�@�A�C�e���Ƃ��̌���\��
        if(itemQuantity > 0)
        {
            itemInBP.SetActive(true);
        }
        itemQTYText.text = itemQuantity.ToString();
        // �I�������A�C�e�����Z�b�g
        SelectedItems.SetSelectedItem(myItemData);

        if (switch1 == true)
        {
            quantity1 = itemQuantity;
        }
        if (switch2 == true)
        {
            quantity2 = itemQuantity;
        }
        if (switch3 == true)
        {
            quantity3 = itemQuantity;
        }
        if (switch4 == true)
        {
            quantity4 = itemQuantity;
        }
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
