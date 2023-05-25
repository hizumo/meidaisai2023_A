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
        itemDataList.Add(new ItemData(Resources.Load("Item1", typeof(Sprite)) as Sprite, "�A�C�e���P", ItemType.Item1, "�P�ڂ̃A�C�e���ł�"));
        itemDataList.Add(new ItemData(Resources.Load("Item2", typeof(Sprite)) as Sprite, "�A�C�e���Q", ItemType.Item1, "�Q�ڂ̃A�C�e���ł�"));
        itemDataList.Add(new ItemData(Resources.Load("Item3", typeof(Sprite)) as Sprite, "�A�C�e���R", ItemType.Item1, "�R�ڂ̃A�C�e���ł�"));
    }

    //�@�S�A�C�e���f�[�^��Ԃ�
    public List<ItemData> GetItemDataList()
    {
        return itemDataList;
    }

    //�@�X�̃A�C�e���f�[�^��Ԃ�
    public ItemData GetItemData(string itemName)
    {
        foreach (var item in itemDataList) 
        {
            if(item.GetItemName() ==  itemName)
            {
                return item;
            }
        }
        return null;   }
}
