using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] UIInventoryPage inventoryPage;

    [SerializeField] int inventorySize;

    private void Start()
    {
        inventoryPage.InicializeInventoryUI(inventorySize);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryPage.isActiveAndEnabled == false)
                inventoryPage.Show();
            else
                inventoryPage.Hide(); 
        }
    }
}
