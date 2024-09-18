using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUIController : MonoBehaviour
{
    public DynamicInventoryDisplay inventoryPannel;

    private void OnEnable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequest += DisplayInventory;
    }

    private void OnDisable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequest -= DisplayInventory;
    }

    // Update is called once per frame
    void Update()
    {
        if(inventoryPannel.gameObject.activeInHierarchy && Keyboard.current.escapeKey.wasPressedThisFrame)
            inventoryPannel.gameObject.SetActive(false);
    }

    public void DisplayInventory(InventorySystem invToDisplay)
    {
        inventoryPannel.gameObject.SetActive(true);
        inventoryPannel.RefreshDynamicInventory(invToDisplay);
    }
}
