using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    [SerializeField] private InventoryItemData itemData;
    [SerializeField] private int stackSize;

    public InventoryItemData ItemData => itemData;
    public int StackSize => stackSize;

    public InventorySlot(InventoryItemData source, int amount)
    {
        itemData = source;
        stackSize = amount;
    }

    public InventorySlot()
    {
        ClearSlot();
    }

    public void UpdateInventorySlot(InventoryItemData source, int amount)
    {
        itemData = source;
        stackSize = amount;
    }

    public void ClearSlot()
    {
        itemData = null;
        stackSize = -1;
    }

    public bool RoomLeftInStack(int amountToAdd, out int amountRemainig)
    {
        amountRemainig = itemData.maxStackSize - stackSize;
        return RoomLeftInStack(amountToAdd);
    }

    public bool RoomLeftInStack(int amountToAdd)
    {
        return stackSize + amountToAdd <= itemData.maxStackSize;
    }

    public void AddToStack(int amount)
    {
        stackSize += amount;
    }

    public void RemoveToStack(int amount)
    {
        stackSize -= amount;
        if(stackSize <= 0)
            ClearSlot();
    }

    public void AssingItem(InventorySlot invSlot)
    {
        if(itemData == invSlot.ItemData)
            AddToStack(invSlot.stackSize);
        else { 
            itemData = invSlot.ItemData;
            stackSize = 0;
            AddToStack(invSlot.stackSize);
        }
    }
}
