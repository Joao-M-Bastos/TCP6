using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] int amountOfSlots;
    [SerializeField] InventoryUI[] inventoryUIs;

    OldInventorySlot[] listOfInventory;

    int[] listOfItems;
    int[] listOfQuantity;

    private void Awake()
    {
        if (listOfInventory != null)
            return;

        listOfInventory = new OldInventorySlot[amountOfSlots];

        for (int i = 0; i < listOfInventory.Length; i++)
        {
            listOfInventory[i] = new OldInventorySlot(i);
            inventoryUIs[i].VinculeSlot(listOfInventory[i]);
        }
    }

    private void Update()
    {
        listOfItems = new int[amountOfSlots];
        listOfQuantity = new int[amountOfSlots];

        if (listOfInventory == null)
            return;

        for (int i = 0;i < listOfItems.Length;i++)
        {
            listOfItems[i] = listOfInventory[i].WhatItemInSlot();
            listOfQuantity[i] = listOfInventory[i].ItemQuantity();
        }
    }


    public void AddItem(int itemID, int quantity)
    {
        int hasSlot = HasAbleSlot(itemID);

        if (hasSlot < 0)
            return;

        listOfInventory[hasSlot].AddItem(itemID, quantity);
    }

    private int HasAbleSlot(int itemID)
    {
        for (int i = 0; i < listOfItems.Length; i++)
        {
            if (listOfInventory[i].WhatItemInSlot() == itemID)
            {
                return i;
            }
        }

        for (int i = 0; i < listOfItems.Length; i++)
        {
            if (!listOfInventory[i].HasItem())
            {
                return i;
            }
        }
        return -1;
    }

    public bool HasItem(int _itemID)
    {
        foreach (OldInventorySlot i in listOfInventory)
        {
            if(i.WhatItemInSlot() == _itemID)
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveItem(int _itemID)
    {
        foreach (OldInventorySlot i in listOfInventory)
        {
            if (i.WhatItemInSlot() == _itemID)
            {
                i.RemoveAnItem();
            }
        }
    }
}
