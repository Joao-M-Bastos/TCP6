using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recicler : MonoBehaviour
{
    [SerializeField] ReciclerCast cast;
    [SerializeField] int materialID;
    [SerializeField] int amountNeeded;
    [SerializeField] int itemToGenerate;
    int currentAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Item itemCollided) && itemCollided.GetItemId() == materialID)
        {
            itemCollided.DeleteItem();
            currentAmount++;
        }
    }

    private void Update()
    {
        CheckForItem();
    }

    private void CheckForItem()
    {
       if(currentAmount >= amountNeeded && !cast.HasItem())
        {
            GenerateItem();
            currentAmount -= amountNeeded;
        }
    }

    private void GenerateItem()
    {
        cast.CastItem(itemToGenerate);
    }
}
