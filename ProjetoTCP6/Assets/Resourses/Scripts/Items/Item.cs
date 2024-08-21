using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] int ID;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.up / 100 * Mathf.Sin(Time.time * 2));
        transform.Rotate(transform.up, Time.deltaTime * 5);
    }

    public void CollectItem()
    {
        Inventory inventory = FindAnyObjectByType<Inventory>();

        inventory.AddItem(ID, 1);

        Destroy(this.gameObject);
    }
}
