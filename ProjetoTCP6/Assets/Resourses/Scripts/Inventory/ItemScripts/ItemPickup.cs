using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickup : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20;
    public float pickupRadius = 1;

    public InventoryItemData itemData;

    private SphereCollider myCollider;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = pickupRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        InventoryHolder inventory = other.GetComponent<InventoryHolder>();

        if (inventory && itemData.isBuff)
        {
            GameObject.FindGameObjectWithTag("Bag").GetComponent<InventoryHolder>().InventorySystem.AddToInventory(itemData,1);

            Destroy(gameObject);
        }else if (inventory && inventory.InventorySystem.AddToInventory(itemData, 1))
        {
            Destroy(gameObject);
        }
        else if (other.TryGetComponent(out Recicler recicler))
        {
            recicler.AddItem(this.itemData, out bool consumed);
            if (consumed)
                Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("ThreadMill"))
        {
            transform.position += other.transform.forward * Time.deltaTime;
        }
    }
}
