using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] MouseItemData mouseInventoryItem;
    protected InventorySystem inventorySystem;

    protected Dictionary<InventorySlot_UI, InventorySlot> slotDictionary;

    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InventorySlot_UI, InventorySlot> SlotDictionary => slotDictionary;

    protected virtual void Start()
    {

    }

    public abstract void AssingSlot(InventorySystem invToDisplay);

    protected virtual void UpdateSlot(InventorySlot updatedSlot)
    {
        foreach (var slot in SlotDictionary)
        {
            if(slot.Value == updatedSlot)
            {
                slot.Key.UpdateUISlot();
            }
        }
    }

    public void SlotClicked(InventorySlot_UI clickedUISlot) 
    {
        if(clickedUISlot.AssingInventorySlot.ItemData != null && mouseInventoryItem.AssingInventorySlot.ItemData == null)
        {
            mouseInventoryItem.UpdateMouseSlot(clickedUISlot.AssingInventorySlot);
            clickedUISlot.ClearSlot();
            return;
        }

        if (clickedUISlot.AssingInventorySlot.ItemData == null && mouseInventoryItem.AssingInventorySlot.ItemData != null)
        {
            clickedUISlot.AssingInventorySlot.AssingItem(mouseInventoryItem.AssingInventorySlot);
            clickedUISlot.UpdateUISlot();
            mouseInventoryItem.ClearSlot();
            return;
        }

        
    }

    private void SwapSlots(InventorySlot_UI clickedSlot)
    {
        InventorySlot cloneInventory = new InventorySlot(mouseInventoryItem.AssingInventorySlot.ItemData, mouseInventoryItem.AssingInventorySlot.StackSize);

        mouseInventoryItem.ClearSlot();

        mouseInventoryItem.UpdateMouseSlot(clickedSlot.AssingInventorySlot);

        clickedSlot.ClearSlot();
        clickedSlot.AssingInventorySlot.AssingItem(cloneInventory);
    }
}
