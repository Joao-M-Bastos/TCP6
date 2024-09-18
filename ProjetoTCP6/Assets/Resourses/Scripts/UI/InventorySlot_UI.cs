using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot_UI : MonoBehaviour
{
    [SerializeField] private Image itemSprit;
    [SerializeField] private TextMeshProUGUI itemCount;

    [SerializeField] private InventorySlot assingInventorySlot;

    private Button button;

    public InventorySlot AssingInventorySlot => assingInventorySlot;
    public InventoryDisplay parentDisplay { get; private set; }

    private void Awake()
    {
        ClearSlot();

        button = GetComponent<Button>();

        itemSprit.preserveAspect = true;

        button?.onClick.AddListener(OnUISlotClick);
        parentDisplay = transform.parent.GetComponent<InventoryDisplay>();
    }

    public void Init(InventorySlot slot)
    {
        assingInventorySlot = slot;
        UpdateUISlot(slot);
    }

    private void UpdateUISlot(InventorySlot slot)
    {
        if (slot.ItemData != null)
        {
            itemSprit.sprite = slot.ItemData.itemsIcon;
            itemSprit.color = Color.white;
        }
        else ClearSlot();


        if (slot.StackSize > 1) itemCount.text = slot.StackSize.ToString();
        else itemCount.text = null;
    }

    public void UpdateUISlot()
    {
        if (assingInventorySlot.ItemData != null) UpdateUISlot(assingInventorySlot);
        else ClearSlot();
    }

    public void OnUISlotClick()
    {
        parentDisplay.SlotClicked(this);
    }

    public void ClearSlot()
    {
        assingInventorySlot?.ClearSlot();

        itemSprit.sprite = null;
        itemSprit.color = Color.clear;
        itemCount.text = string.Empty;
    }
}
