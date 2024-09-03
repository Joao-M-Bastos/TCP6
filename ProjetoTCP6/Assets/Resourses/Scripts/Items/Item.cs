using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] int ID;
    [SerializeField] GameObject body;
    [SerializeField] Sprite icon;
    [SerializeField] ItemCollectCallback cameraAnimation;

    // Update is called once per frame
    void FixedUpdate()
    {
        body.transform.Translate(transform.up / 100 * Mathf.Sin(Time.time * 2));
        body.transform.Rotate(transform.up, Time.deltaTime * 5);
    }

    public void CollectItem()
    {
        Inventory inventory = FindAnyObjectByType<Inventory>();

        if (ID == 3)
        {
            cameraAnimation.Collected();
        }
        else
        {
            inventory.AddItem(ID, 1);
        }
        

        

        Destroy(this.gameObject);
    }

    public void OnCollect()
    {
        
    }

    public int GetItemId()
    {
        return ID;
    }

    public Sprite GetSprite()
    {
        return icon;
    }

    public void DeleteItem()
    {
        Destroy(this.gameObject);
    }
}
