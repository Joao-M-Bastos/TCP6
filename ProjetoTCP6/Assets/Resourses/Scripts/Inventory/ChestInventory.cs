using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestInventory : InventoryHolder, IInteractable
{
    public UnityAction<IInteractable> onInteractionComplete { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void Interact(Interactor interactor, out bool interactionSuccess)
    {
        OnDynamicInventoryDisplayRequest?.Invoke(inventorySystem);
        interactionSuccess = true;
    }

    public void EndInteraction()
    {
    }

    public void HasInteracted(Interactor interactor, out bool hasInteracted)
    {
        hasInteracted = false;
    }
}
