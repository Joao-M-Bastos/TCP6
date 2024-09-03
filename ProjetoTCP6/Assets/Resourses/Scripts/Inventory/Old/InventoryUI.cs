using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Image itemIcon;
    [SerializeField] TextMeshProUGUI itemName, quantity;
    
    OldInventorySlot slot;

    public void VinculeSlot(OldInventorySlot _slot)
    {
        slot = _slot;
    }

    // Update is called once per frame
    void Update()
    {
        if (slot == null )
            return;

        if (!slot.HasItem())
        {
            itemIcon.sprite = null;
            itemName.text = "----";
            quantity.text = "----";
            return;
        }
        GameObject item = ListOfItems.GetItemById(slot.WhatItemInSlot());
        Item itemScpt = item.GetComponent<Item>();

        itemIcon.sprite = itemScpt.GetSprite();
        itemName.text = item.name;
        quantity.text = slot.ItemQuantity().ToString();
                
    }
}
