using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase;

    [SerializeField] private GameObject itemButton;

    private ItemData myItemData;

    private TextMeshProUGUI itemQTYText;
    private int itemQuantity = 3;

    private GameObject information;
    private TextMeshProUGUI informationText;

    [SerializeField] bool isShoesUse = false;

    private GameObject UseItemsUI;
    private TextMeshProUGUI panelYText;
    UseItems useItems;
   
    public static bool Item2 = true;

    void Start()
    {
        //�@�A�C�e���f�[�^���X�g���擾
        List<ItemData> myItemDataList = itemDataBase.GetItemDataList();
       
        //�@�Ή�����A�C�e���f�[�^���擾
        myItemData = itemDataBase.GetItemData(itemButton.name);
        //�@�A�C�e���̌��̕\��UI���擾
        itemQTYText = itemButton.GetComponentInChildren<TextMeshProUGUI>();
        itemQTYText.text = itemQuantity.ToString();
        //�@�A�C�e�����̕\��UI���擾
        information = GameObject.Find("InventoryUI/Panel/Information");
        informationText = information.GetComponentInChildren<TextMeshProUGUI>();
        //�����V���[�Y���񕜖�Ȃ�A�A�C�e���g�p�̏���������
        if(itemButton.name == "Item2" || itemButton.name == "Item3")
        {
            UseItemsUI = GameObject.Find("InventoryUI/Panel/UseItemsUI");
            useItems = UseItemsUI.GetComponent<UseItems>();
            panelYText = GameObject.Find("InventoryUI/Panel/PanelY").GetComponentInChildren<TextMeshProUGUI>();
        }
        
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
        }*/
        if(itemButton.name == "Item2")
        {
            StartCoroutine(ShowMsg());
            panelYText.text = "�ړ����x�A�b�v�I";
            Item2 = true;
            //Question �Ƃ������O�̃I�u�W�F�N�g���擾
            GameObject objb = GameObject.Find("BackButton");
            objb.gameObject.SetActive(false);
        }

 

        if (itemButton.name == "Item3")
        {
            StartCoroutine(ShowMsg());
            panelYText.text = "�̗͂�10�񕜁I";
            Item2 = false;
            //Question �Ƃ������O�̃I�u�W�F�N�g���擾
            GameObject objb = GameObject.Find("BackButton");
            objb.gameObject.SetActive(false);
        }
        /*if (itemButton.name == "Item3") // || itemButton.name == "Item3")
        {
            UseItemsUI.SetActive(true);
            UseItems useItems = UseItemsUI.GetComponentInChildren<UseItems>();
            if (useItems.isItemUsed == true)
            {
                itemQuantity--;
                
                useItems.isItemUsed = false;
                Debug.Log("�V���[�Y���g�p");
            }
        }*/
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
    IEnumerator ShowMsg()
    {
        UseItemsUI.SetActive(true);
        useItems.isButtonClicked = false;
        yield return new WaitUntil(() => useItems.isButtonClicked == true);

        if (useItems.isItemUsed == true)
        {
            itemQuantity--;
            isShoesUse = true;
            useItems.isItemUsed = false;
            //Debug.Log("used");
        }
        //else{Debug.Log("not used");}

        if (itemQuantity == 0)
        {
            itemButton.SetActive(false);
        }
        //itemQuantity = myItemData.GetItemQuantity();
        itemQTYText.text = itemQuantity.ToString();
        //Debug.Log(itemQuantity.ToString());
    }
    
}

