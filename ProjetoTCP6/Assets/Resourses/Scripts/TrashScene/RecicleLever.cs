using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RecicleLever : MonoBehaviour, IInteractable
{
    [SerializeField] Recicler recicler;
    Animator animator;

    public UnityAction<IInteractable> onInteractionComplete { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void EndInteraction()
    {

    }

    public void Interact(Interactor interactor, out bool interactionSuccess)
    {
        interactionSuccess = false;
        if (!recicler.IsActive)
        {
            animator.SetTrigger("Open");
            interactionSuccess = true;
            recicler.ActivateRecicler();
        }

    }

    public void HasInteracted(out bool hasInteracted)
    {
        hasInteracted = recicler.IsActive;
    }
}
