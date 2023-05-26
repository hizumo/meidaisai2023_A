using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    //�@�A�C�e����Image�摜
    private Sprite itemSprite;
    //�@�A�C�e���̖��O
    private string itemName;
    //�@�A�C�e���̃^�C�v
    private ItemDataBase.ItemType itemType;
    //�@�A�C�e���̏��
    private string itemInformation;
    //�@�A�C�e���̌�
    private int itemQuantity;

    public ItemData(string itemName, ItemDataBase.ItemType itemType, string information, int itemQuantity)//(Sprite image, string itemName, ItemDataBase.ItemType itemType, string information, int itemQuantity)
    {
        //this.itemSprite = image;
        this.itemName = itemName;
        this.itemType = itemType;
        this.itemInformation = information;
    }

    /*public Sprite GetItemSprite()
    {
        return itemSprite;
    }*/

    public string GetItemName()
    {
        return itemName;
    }

    public ItemDataBase.ItemType GetItemType()
    {
        return itemType;
    }

    public string GetItemInformation()
    {
        return itemInformation;
    }

    public int GetItemQuantity() 
    {
        return itemQuantity;
    }

    public int ChangeItemQuantity(int item)
    {
        itemQuantity = item;
        return itemQuantity;
    }
}