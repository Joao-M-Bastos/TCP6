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

    internal void UpdateMouseSlot(InventorySlot invSlot)
    {
        AssingInventorySlot.AssingItem(invSlot);
        itemSprite.sprite = invSlot.ItemData.itemsIcon;
        itemCount.text = invSlot.StackSize.ToString();
        itemSprite.color = Color.white;
    }

    private void Awake()
    {
        itemSprite.color = Color.clear;
        itemCount.text = null;
    }

    private void Update()
    {
        if(AssingInventorySlot.ItemData != null)
        {
            transform.position = Mouse.current.position.ReadValue();
            

            if(Mouse.current.leftButton.isPressed && !IsPointerOverUI())
            {
                ClearSlot();
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
