using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recicler : MonoBehaviour
{
    [SerializeField] int materialID, itemToGenerate;
    [SerializeField] int amountNeeded;
    [SerializeField] ItemDataBase itemDatabase;
    bool itemGenerated;
    int currentAmount;

    public void AddItem(InventoryItemData itemToAdd)
    {
        if (itemToAdd.ID == materialID)
        {
            currentAmount++;
            CheckForItem();
        }
        else
        {
            currentAmount = 0;
        }
    }

    private void CheckForItem()
    {
       if(currentAmount >= amountNeeded )
        {
            GenerateItem();
            currentAmount -= amountNeeded;
        }
    }

    private void GenerateItem()
    {
        if (itemGenerated)
            return;

        itemGenerated = true;
        Instantiate(itemDatabase.GetItem(itemToGenerate).itemPrefab, transform.position, Quaternion.identity);
    }
}
