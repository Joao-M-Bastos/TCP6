using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInventoryDisplay : InventoryDisplay
{
    [SerializeField] protected InventoryHolder inventoryHolder;
    [SerializeField] protected InventorySlot_UI[] slots;

    virtual protected void OnEnable()
    {
       
    }

    virtual protected void OnDisable()
    {
        
    }


    protected void Start()
    {
        RefreshInventory();
    }

    protected void RefreshInventory()
    {
        if (inventoryHolder != null)
        {
            inventorySystem = inventoryHolder.InventorySystem;
            inventorySystem.OnInventorySlotChanged += UpdateSlot;
        }
        else
            Debug.LogWarning($"No inventory Assing to {this.gameObject}");

        AssingSlot(inventorySystem);
    }

    public override void AssingSlot(InventorySystem invToDisplay)
    {
        slotDictionary = new Dictionary<InventorySlot_UI, InventorySlot>();

        if (slots.Length != inventorySystem.InventorySize) Debug.Log($"Inventory Slots out of sinc in {this.gameObject}");

        for (int i = 0; i < inventorySystem.InventorySize; i++)
        {
            slotDictionary.Add(slots[i], inventorySystem.InventorySlots[i]);
            slots[i].Init(inventorySystem.InventorySlots[i]);
        }
    }
}
