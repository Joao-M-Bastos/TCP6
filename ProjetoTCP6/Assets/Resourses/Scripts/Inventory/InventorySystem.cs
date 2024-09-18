using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using System;

[System.Serializable]
public class InventorySystem
{
    [SerializeField] private List<InventorySlot> inventorySlots;

    public List<InventorySlot> InventorySlots => inventorySlots;

    public int InventorySize => inventorySlots.Count;


    public UnityAction<InventorySlot> OnInventorySlotChanged;


    public InventorySystem(int size)
    {
        inventorySlots = new List<InventorySlot>(size);

        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddToInventory(InventoryItemData itemToAdd, int amountToAdd)
    {
        //If Item is already in Inventory
        if (ContainItem(itemToAdd, out List<InventorySlot> invSlot))
        {
            foreach(InventorySlot slot in invSlot)
            {
                if (slot.RoomLeftInStack(amountToAdd))
                {
                    slot.AddToStack(amountToAdd);
                    OnSlotChanged(slot);
                    return true;
                }
            }
            
        }
        //If slot is free
        if (HasFreeSlot(out InventorySlot freeSlot))
        {
            freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
            OnInventorySlotChanged?.Invoke(freeSlot);
            return true;
        }
        return false;
    }

    public bool ContainItem(InventoryItemData itemToAdd, out List<InventorySlot> invSlot)
    {

        invSlot = inventorySlots.Where(i => i.ItemData == itemToAdd).ToList();
        
        return invSlot != null;
    }

    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        freeSlot = inventorySlots.FirstOrDefault(i => i.ItemData == null);
        return freeSlot != null;
    }

    public void OnSlotChanged(InventorySlot slot)
    {
        OnInventorySlotChanged?.Invoke(slot);
    }
}
