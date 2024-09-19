using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recicler : MonoBehaviour
{
    [SerializeField] int materialID, itemToGenerate;
    [SerializeField] int amountNeeded;
    [SerializeField] ItemDataBase itemDatabase;
    [SerializeField] GameObject spriteIcon;
    bool isActive;
    bool itemGenerated;
    int currentAmount;

    [SerializeField]  

    public bool IsActive => isActive;

    public void AddItem(InventoryItemData itemToAdd, out bool consumed)
    {
        consumed = false;
        if (!isActive)
            return;

        if (itemToAdd.ID == materialID)
        {
            consumed = true;
            currentAmount++;
            CheckForItem();
        }
        else
        {
            RecicleCounter.instance.AddRecicleAmount();
            currentAmount = 0;
        }
        
    }

    public void ActivateRecicler()
    {
        isActive= true;
        spriteIcon.SetActive(isActive);
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
