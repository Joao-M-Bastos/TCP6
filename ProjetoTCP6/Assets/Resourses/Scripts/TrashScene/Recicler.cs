using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.PostProcessing;

public class Recicler : MonoBehaviour, IInteractable
{
    [SerializeField] int materialID, itemToGenerate, itemToExtraGenerate;
    [SerializeField] int amountNeeded;
    [SerializeField] ItemDataBase itemDatabase;
    [SerializeField] GameObject spriteIcon;
    [SerializeField] DialogueTrigger goodDialogue, badDialogue;

    bool isActive;
    bool itemGenerated;
    int currentAmount;

    public bool IsActive => isActive;

    public UnityAction<IInteractable> onInteractionComplete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void AddItem(InventoryItemData itemToAdd, out bool consumed)
    {
        consumed = false;
        if (!isActive)
            return;

        if (itemToAdd.ID == materialID)
        {
            
            consumed = true;
            currentAmount++;
            CheckForItem();
        }
        else
        {
            //badDialogue.TriggerDialogueEvent();
            RecicleCounter.instance.AddRecicleAmount();
            currentAmount = 0;
        }
        
    }

    public void ActivateRecicler()
    {
        isActive= true;
        spriteIcon.SetActive(isActive);
    }

    private void CheckForItem()
    {
       if(currentAmount >= amountNeeded )
        {

            GenerateItem();
            currentAmount -= amountNeeded;
        }
    }

    private void GenerateItem()
    {
        RecicleCounter.instance.RemoveRecicleAmount();
        if (itemGenerated)
        {
            Instantiate(itemDatabase.GetItem(itemToExtraGenerate).itemPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            //goodDialogue.TriggerDialogueEvent();

            itemGenerated = true;
            Instantiate(itemDatabase.GetItem(itemToGenerate).itemPrefab, transform.position, Quaternion.identity);
        }

        
    }

    public void Interact(Interactor interactor, out bool interactionSuccess)
    {
        interactionSuccess = false;
        
        if (interactor.gameObject.TryGetComponent(out InventoryHolder playerInventory))
        {
            if(playerInventory.InventorySystem.ContainItem(itemDatabase.GetItem(materialID),out List<InventorySlot> invSlots))
            {
                if (invSlots.Count > 0)
                {
                    AddItem(itemDatabase.GetItem(materialID), out bool consumed);
                    if (consumed)
                    {
                        interactionSuccess = true;
                        invSlots[0].RemoveToStack(1);
                        playerInventory.InventorySystem.OnSlotChanged(invSlots[0]);
                    }
                    
                }
            }
        }
    }

    public void EndInteraction()
    {
        throw new NotImplementedException();
    }

    public void HasInteracted(Interactor interactor, out bool hasInteracted)
    {
        hasInteracted = !isActive;
    }

}
