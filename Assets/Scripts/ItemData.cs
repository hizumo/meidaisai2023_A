using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    //　アイテムのImage画像
    private Sprite itemSprite;
    //　アイテムの名前
    private string itemName;
    //　アイテムのタイプ
    private ItemDataBase.ItemType itemType;
    //　アイテムの情報
    private string itemInformation;
    //　アイテムの個数
    private int itemQuantity;
    //　アイテムの重さ
    private float itemWeight;

    public ItemData(string itemName, ItemDataBase.ItemType itemType, string information, int itemQuantity, float itemWeight)
    {
        //this.itemSprite = image;
        this.itemName = itemName;
        this.itemType = itemType;
        this.itemInformation = information;
        this.itemQuantity = itemQuantity;
        this.itemWeight = itemWeight;
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

    public float GetItemWeight() 
    {
        return itemWeight;
    }
}