using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public virtual void SlotClicked(InventorySlot_UI clickedUISlot)
    {
        if (clickedUISlot.AssingInventorySlot.ItemData != null && mouseInventoryItem.AssingInventorySlot.ItemData == null)
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


        if (clickedUISlot.AssingInventorySlot.ItemData != null && mouseInventoryItem.AssingInventorySlot.ItemData != null)
        {
            //Se os items são iguais
            bool isSameItem = clickedUISlot.AssingInventorySlot.ItemData == mouseInventoryItem.AssingInventorySlot.ItemData;
            
            //Se cabe a quantidade de items no mause dentro da hotbar
            if (isSameItem && clickedUISlot.AssingInventorySlot.RoomLeftInStack(mouseInventoryItem.AssingInventorySlot.StackSize))
            {
                clickedUISlot.AssingInventorySlot.AssingItem(mouseInventoryItem.AssingInventorySlot);
                clickedUISlot.UpdateUISlot();
                mouseInventoryItem.ClearSlot();
            }else if(isSameItem && !clickedUISlot.AssingInventorySlot.RoomLeftInStack(mouseInventoryItem.AssingInventorySlot.StackSize, out int leftInStack))
            {
                if (leftInStack < 1)
                {
                    SwapSlots(clickedUISlot);//swap the items if stack is full
                }
                else
                {
                    int remaningOnMouse = mouseInventoryItem.AssingInventorySlot.StackSize - leftInStack;

                    clickedUISlot.AssingInventorySlot.AddToStack(leftInStack);
                    InventorySlot newItem = new InventorySlot(mouseInventoryItem.AssingInventorySlot.ItemData, remaningOnMouse);
                    mouseInventoryItem.ClearSlot();

                    mouseInventoryItem.UpdateMouseSlot(newItem);

                    clickedUISlot.UpdateUISlot();

                }
            }else if (!isSameItem)
                SwapSlots(clickedUISlot);
        }
    }
    private void SwapSlots(InventorySlot_UI clickedSlot)
    {
        InventorySlot cloneInventory = new InventorySlot(mouseInventoryItem.AssingInventorySlot.ItemData, mouseInventoryItem.AssingInventorySlot.StackSize);

        mouseInventoryItem.ClearSlot();

        mouseInventoryItem.UpdateMouseSlot(clickedSlot.AssingInventorySlot);

        clickedSlot.ClearSlot();
        clickedSlot.AssingInventorySlot.AssingItem(cloneInventory);
        clickedSlot.UpdateUISlot();
    }
}
