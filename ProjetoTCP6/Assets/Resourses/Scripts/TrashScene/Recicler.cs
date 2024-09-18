using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recicler : MonoBehaviour
{
    [SerializeField] int materialID, itemToGenerate;
    [SerializeField] int amountNeeded;
    [SerializeField] ItemDataBase itemDatabase;
    bool isActive;
    bool itemGenerated;
    int currentAmount;

    public bool IsActive => isActive;

    public void AddItem(InventoryItemData itemToAdd, out bool consumed)
    {
        consumed = false;
        if (!isActive)
            return;

        if (itemToAdd.ID == materialID)
        {
            currentAmount++;
            CheckForItem();
        }
        else
        {
            RecicleCounter.instance.AddRecicleAmount();
            currentAmount = 0;
        }
        consumed = true;
    }

    public void ActivateRecicler()
    {
        isActive= true;
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
        RecicleCounter.instance.RemoveRecicleAmount();
        if (itemGenerated)
            return;

        itemGenerated = true;
        Instantiate(itemDatabase.GetItem(itemToGenerate).itemPrefab, transform.position, Quaternion.identity);
    }
}
