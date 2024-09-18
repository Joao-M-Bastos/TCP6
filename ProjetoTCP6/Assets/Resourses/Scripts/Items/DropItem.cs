using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] InventoryItemData itemToDrop;
    [SerializeField] float dropChance;
    // Start is called before the first frame update
    public void DropItemCall()
    {
        if (Random.Range(0, 100) > dropChance)
            return;

        Instantiate(itemToDrop.itemPrefab, this.transform.position, Quaternion.identity);
    }
}
