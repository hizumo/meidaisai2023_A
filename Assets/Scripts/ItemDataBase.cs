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
        RayGun,
        Ore1,
        Ore2,
        Ore3
    }

   //�@�A�C�e���f�[�^�̃��X�g
    public List<ItemData> itemDataList = new List<ItemData>();

    void Awake()
    {
        //�@�A�C�e���̑S���𐶐�
        itemDataList.Add(new ItemData("Item1", ItemType.PickAxe, "<size=84><b>�c���n�V</b>\n<size=60>�̌@���̏���̗͂��y������B", 0, 1.1f)); //Resources.Load("Item1") as Sprite, "Item1", ItemType.PickAxe "�P�ڂ̃A�C�e���ł�", 0));
        itemDataList.Add(new ItemData("Item2", ItemType.AccelShoes, "<size=84><b>�V���[�Y</b>\n<size=60>��莞�Ԉړ����x���グ��B", 0, 0.5f));//Resources.Load("Item2") as Sprite, "Item2", ItemType.SpeedShoes, "�Q�ڂ̃A�C�e���ł�", 0));
        itemDataList.Add(new ItemData("Item3", ItemType.HealingItem, "<size=84><b>�񕜖�</b>\n<size=60>�̗͂����l�񕜂���B", 0, 0.4f));//Resources.Load("Item3") as Sprite, "Item3", ItemType.HealingItem, "�R�ڂ̃A�C�e���ł�", 0));    
        itemDataList.Add(new ItemData("Item4", ItemType.RayGun, "<size=84><b>�����e</b>\n<size=60>�G�����݂����ނ���B", 0, 0.7f));
        itemDataList.Add(new ItemData("Item5", ItemType.Ore1, "<size=84><b>�����z��</b>\n<size=60>���Ƃ�������Əd�����B", 0, 1.6f));
        itemDataList.Add(new ItemData("Item6", ItemType.Ore2, "<size=84><b>�P���z��</b>\n<size=60>�y���ĊȒP�Ɏ��Ă�B", 0, 0.3f));
        itemDataList.Add(new ItemData("Item7", ItemType.Ore3, "<size=84><b>�g�Q�g�Q�̍z��</b>\n<size=60>�̌@����̂ɑ𑽂̗͂��g���B", 0, 1.2f));
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
