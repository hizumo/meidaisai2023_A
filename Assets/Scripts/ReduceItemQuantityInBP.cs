using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReduceItemQuantityInBP : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase;

    [SerializeField] private GameObject itemInBP;

    private ItemData myItemData;

    private TextMeshProUGUI itemQTYText;
    private int itemQuantity = 0;

    private GameObject information;
    private TextMeshProUGUI informationText;


    // Start is called before the first frame update
    void Start()
    {
        List<ItemData> myItemDataList = itemDataBase.GetItemDataList();

        //�@�Ή�����A�C�e���f�[�^���擾
        myItemData = itemDataBase.GetItemData(itemInBP.name);
        //�@�A�C�e���̌��̕\��UI���擾
        itemQTYText = itemInBP.GetComponentInChildren<TextMeshProUGUI>();
        //�@�A�C�e�����̕\��UI���擾
        information = GameObject.Find("ItemSelectUI/Panel/Information");
        informationText = information.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnClick()
    {        
        //�@�A�C�e���̌����擾���A�[�P����
        itemQuantity = myItemData.GetItemQuantity();
        itemQuantity--;
        //Debug.Log(itemQuantity.ToString());
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
    public void MouseOver()
    {
        informationText.text = myItemData.GetItemInformation();
        //Debug.Log("MouseOver");
    }
    public void MouseExit()
    {
        informationText.text = "";
       // Debug.Log("MouseExit");
    }
}
