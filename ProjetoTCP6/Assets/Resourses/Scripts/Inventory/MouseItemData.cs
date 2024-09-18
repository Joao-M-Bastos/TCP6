using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MouseItemData : MonoBehaviour
{
    public Image itemSprite;
    public TextMeshProUGUI itemCount;

    public InventorySlot AssingInventorySlot;

    private Transform playerTransform;

    internal void UpdateMouseSlot(InventorySlot invSlot)
    {
        AssingInventorySlot.AssingItem(invSlot);
        UpdateMouseSlot();
    }

    internal void UpdateMouseSlot()
    {
        itemSprite.sprite = AssingInventorySlot.ItemData.itemsIcon;
        itemCount.text = AssingInventorySlot.StackSize.ToString();
        itemSprite.color = Color.white;
    }

    private void Awake()
    {
        itemSprite.preserveAspect = true;
        itemSprite.color = Color.clear;
        itemCount.text = null;

        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    private void Update()
    {
        if(AssingInventorySlot.ItemData != null)
        {
            transform.position = Mouse.current.position.ReadValue();
            

            if(Mouse.current.leftButton.wasPressedThisFrame && !IsPointerOverUI())
            {
                if (AssingInventorySlot.ItemData.itemPrefab != null)
                {
                    Instantiate(AssingInventorySlot.ItemData.itemPrefab, playerTransform.position + playerTransform.forward * 1.5f, Quaternion.identity);
                    
                    if(AssingInventorySlot.StackSize > 1)
                    {
                        AssingInventorySlot.AddToStack(-1);
                        UpdateMouseSlot();
                    }
                    else
                        ClearSlot();
                }
            }
        }
    }

    public void ClearSlot()
    {
        AssingInventorySlot.ClearSlot();
        itemCount.text = null;
        itemSprite.color = Color.clear;
        itemSprite.sprite = null;
    }

    public static bool IsPointerOverUI()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);

        eventDataCurrentPosition.position = Mouse.current.position.ReadValue();

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition , results);
        return results.Count > 0;
    } 
}
