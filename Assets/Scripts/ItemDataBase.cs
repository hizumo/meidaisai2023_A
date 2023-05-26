using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{

    //�@�A�C�e���̎��
    public enum ItemType
    {
        Item1,
        Item2,
        Item3
    }

   //�@�A�C�e���f�[�^�̃��X�g
    public List<ItemData> itemDataList = new List<ItemData>();

    void Awake()
    {
        //�@�A�C�e���̑S���𐶐�
        itemDataList.Add(new ItemData("Item1", ItemType.Item1, "�P�ڂ̃A�C�e���ł�", 0)); //Resources.Load("Item1") as Sprite, "Item1", ItemType.Item1, "�P�ڂ̃A�C�e���ł�", 0));
        itemDataList.Add(new ItemData("Item2", ItemType.Item2, "�Q�ڂ̃A�C�e���ł�", 0));//Resources.Load("Item2") as Sprite, "Item2", ItemType.Item2, "�Q�ڂ̃A�C�e���ł�", 0));
        itemDataList.Add(new ItemData("Item3", ItemType.Item3, "�R�ڂ̃A�C�e���ł�", 0));//Resources.Load("Item3") as Sprite, "Item3", ItemType.Item3, "�R�ڂ̃A�C�e���ł�", 0));    
    }

    //�@�A�C�e���f�[�^���X�g���擾
    public List<ItemData> GetItemDataList()
    {
        return itemDataList;
    }
    //�@�X�̃A�C�e���f�[�^��Ԃ�
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
