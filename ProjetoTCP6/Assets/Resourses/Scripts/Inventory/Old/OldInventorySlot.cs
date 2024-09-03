using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldInventorySlot
{
    int slotID;
    int itemId;
    int itemAmount;

    public OldInventorySlot(int slotID)
    {
        this.slotID = slotID;
        this.itemId = -1;
        this.itemAmount = 0;
    }

    public int GetSlotId()
    {
        return itemId;
    }

    public bool HasItem()
    {
        return itemId != -1;
    }

    public int WhatItemInSlot()
    {
        return itemId;
    }

    public int ItemQuantity()
    {
        return itemAmount;
    }

    public void ClearSlot()
    {
        itemId = -1;
        itemAmount = 0;
    }

    public int RemoveAnItem()
    {
        int itemToReturn = WhatItemInSlot();

        itemAmount--;

        if (itemAmount <= 0)
        {
            ClearSlot();
        }
        return itemToReturn;
    }


    public void AddItem(int _itemId, int amountToAdd)
    {
        if (itemId == -1)
            itemId = _itemId;


        if (this.itemId == _itemId)
            itemAmount += amountToAdd;

    }
}
