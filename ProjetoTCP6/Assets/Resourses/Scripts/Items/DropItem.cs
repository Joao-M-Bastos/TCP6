using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] int itemID;
    [SerializeField] float dropChance;
    // Start is called before the first frame update
    public void DropItemCall()
    {
        if (Random.Range(0, 100) > dropChance)
            return;

        GameObject itemToDrop = ListOfItems.GetItemById(itemID);

        Instantiate(itemToDrop, this.transform.position, itemToDrop.transform.rotation);
    }
}
