using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] ItemDataBase itemDataBase;
    [SerializeField] int keyNeeded;
    [SerializeField] GameObject fog;
    bool isOpend;
    Animator animator;

    public UnityAction<IInteractable> onInteractionComplete { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        isOpend = false;
    }

    public void Interact(Interactor interactor, out bool interactionSuccess)
    {

        interactionSuccess = false;

        if (isOpend)
            return;

        if (interactor.gameObject.TryGetComponent(out InventoryHolder playerInv))
        {
            playerInv.InventorySystem.ContainItem(itemDataBase.GetItem(keyNeeded),out List<InventorySlot> invSlots);

            if (invSlots.Count > 0)
            {
                animator.SetBool("Open", true);
                isOpend = true;
                interactionSuccess = true;
                invSlots[0].RemoveToStack(1);
                Destroy(fog);
                playerInv.InventorySystem.OnSlotChanged(invSlots[0]);
            }
        }
    }

    public void EndInteraction()
    {

    }

    public void HasInteracted(Interactor interactor,out bool hasInteracted)
    {
        hasInteracted = isOpend;
    }
}
