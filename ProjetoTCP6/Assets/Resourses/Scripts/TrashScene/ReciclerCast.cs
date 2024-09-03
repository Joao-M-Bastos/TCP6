using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReciclerCast : Interactable
{
    [SerializeField] Transform placeToCast;

    GameObject itemCast;
    
    public void CastItem(int itemID)
    {
        if (itemCast != null)
            return;

        itemCast = Instantiate(ListOfItems.GetItemById(itemID), placeToCast.position, ListOfItems.GetItemById(itemID).transform.rotation);
    }

    public void TryCollectItem()
    {
        if (itemCast == null)
            return;

        itemCast.GetComponent<Item>().CollectItem();
    }

    public bool HasItem()
    {
        return itemCast != null;
    }

    public override void Interact()
    {
        TryCollectItem();
    }
}
