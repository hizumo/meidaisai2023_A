using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{

    //�@�A�C�e���̎��
    public enum ItemType
    {
        PickAxe,
        AccelShoes,
        HealingItem,
        RayGun
    }

   //�@�A�C�e���f�[�^�̃��X�g
    public List<ItemData> itemDataList = new List<ItemData>();

    void Awake()
    {
        //�@�A�C�e���̑S���𐶐�
        itemDataList.Add(new ItemData("Item1", ItemType.PickAxe, "<size=72><b>�c���n�V</b><size=60>�F�z�΂̍̌@���̏���̗͂��y������B", 0)); //Resources.Load("Item1") as Sprite, "Item1", ItemType.PickAxe "�P�ڂ̃A�C�e���ł�", 0));
        itemDataList.Add(new ItemData("Item2", ItemType.AccelShoes, "<size=72><b>�V���[�Y</b><size=60>�F��莞�Ԉړ����x���A�b�v�B", 0));//Resources.Load("Item2") as Sprite, "Item2", ItemType.SpeedShoes, "�Q�ڂ̃A�C�e���ł�", 0));
        itemDataList.Add(new ItemData("Item3", ItemType.HealingItem, "<size=72><b>�񕜖�</b><size=60>�F�̗͂����l�񕜂���B", 0));//Resources.Load("Item3") as Sprite, "Item3", ItemType.HealingItem, "�R�ڂ̃A�C�e���ł�", 0));    
        itemDataList.Add(new ItemData("Item4", ItemType.RayGun, "<size=72><b>�����e</b><size=60>�F����", 0));
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
