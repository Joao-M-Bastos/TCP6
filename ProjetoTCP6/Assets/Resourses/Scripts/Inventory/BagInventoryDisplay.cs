using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BagInventoryDisplay : StaticInventoryDisplay
{
    public delegate void UsePaper();
    public static UsePaper usePaper;

    public delegate void UsePlastic();
    public static UsePlastic usePlastic;

    public delegate void UseGlass();
    public static UseGlass useGlass;

    public delegate void UseMetal();
    public static UseMetal useMetal;

    [SerializeField] float paperUseCooldown;
    float paperCurrentCooldown;

    int currentPaperSlot;

    public override void SlotClicked(InventorySlot_UI clickedUISlot)
    {
        
    }

    private PlayerControl playerControls;

    private void Awake()
    {
        playerControls = new PlayerControl();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        playerControls.Enable();
        
        playerControls.Player.Hotbar1.performed += UseItem1;
        playerControls.Player.Hotbar2.performed += UseItem2;
        playerControls.Player.Hotbar3.performed += UseItem3;
        playerControls.Player.Hotbar4.performed += UseItem4;
        playerControls.Player.Hotbar4.performed += UseItem5;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        playerControls.Disable();

        playerControls.Player.Hotbar1.performed -= UseItem1;
        playerControls.Player.Hotbar2.performed -= UseItem2;
        playerControls.Player.Hotbar3.performed -= UseItem3;
        playerControls.Player.Hotbar4.performed -= UseItem4;
        playerControls.Player.Hotbar5.performed -= UseItem5;

    }

    private void UseItem1(InputAction.CallbackContext context)
    {
        InventoryItemData itemData = slots[0].AssingInventorySlot.ItemData;

        if (!ConsumeItem(itemData,0))
            return;

        UseItem(itemData);
    }
    private void UseItem2(InputAction.CallbackContext context)
    {
        InventoryItemData itemData = slots[1].AssingInventorySlot.ItemData;

        if (!ConsumeItem(itemData,1))
            return;

        UseItem(itemData);
    }

    

    private void UseItem3(InputAction.CallbackContext context)
    {
        InventoryItemData itemData = slots[2].AssingInventorySlot.ItemData;

        if (!ConsumeItem(itemData,2))
            return;

        UseItem(itemData);
    }
    private void UseItem4(InputAction.CallbackContext context)
    {
        InventoryItemData itemData = slots[3].AssingInventorySlot.ItemData;

        if (!ConsumeItem(itemData,3))
            return;

        UseItem(itemData);
    }

    private void UseItem5(InputAction.CallbackContext context)
    {
        InventoryItemData itemData = slots[4].AssingInventorySlot.ItemData;

        if (!ConsumeItem(itemData,4))
            return;

        UseItem(itemData);
    }

    public bool ConsumeItem(InventoryItemData itemData, int slotID)
    {

        if (itemData == null || !itemData.isBuff) return false;

        inventoryHolder.InventorySystem.ContainItem(itemData, out List<InventorySlot> invSlots);

        if (itemData.ID == 8 && paperCurrentCooldown > 0)
        {
            slots[slotID].gameObject.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.red;
            return false;
        }

        if (invSlots.Count > 0)
        {
            invSlots[0].RemoveToStack(1);
            inventoryHolder.InventorySystem.OnSlotChanged(invSlots[0]);
            return true;
        }

        return false;
    }

    private void UseItem(InventoryItemData itemData)
    {
        switch (itemData.ID)
        {
            case 8:
                paperCurrentCooldown = paperUseCooldown;
                usePaper?.Invoke();
                break;
            case 9:
                usePlastic?.Invoke();
                break;
            case 10:
                useGlass?.Invoke();
                break;
            case 11:
                useMetal?.Invoke();
                break;

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (paperCurrentCooldown > 0)
            paperCurrentCooldown -= Time.deltaTime;
        else
            slots[currentPaperSlot].gameObject.GetComponentInChildren<UnityEngine.UI.Image>().color = new Color(0.4113207f, 0.299347f, 0.2413598f);

    }

}
