using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadMill : Interactable
{

    [SerializeField] float speed;
    [SerializeField] Transform spawnPoint;

    public GameObject[] items;
    int itemQuantity;

    // Start is called before the first frame update
    void Start()
    {
        items = new GameObject[10];
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject item in items)
        {
            if (item != null)
                item.transform.position += this.transform.forward * Time.deltaTime;
        }
    }

    public void TryAddItemToList()
    {
        Inventory inventory = FindAnyObjectByType<Inventory>();

        if (inventory.HasItem(0))
        {
            inventory.RemoveItem(0);

            items[itemQuantity] = Instantiate(ListOfItems.GetItemById(0), spawnPoint.transform);
            itemQuantity++;
        }
        else if (inventory.HasItem(1))
        {
            inventory.RemoveItem(1);

            items[itemQuantity] = Instantiate(ListOfItems.GetItemById(1), spawnPoint.transform);
            itemQuantity++;
        }
    }

    public override void Interact()
    {
        TryAddItemToList();
    }
}
