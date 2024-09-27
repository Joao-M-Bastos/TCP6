using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Tutorial_RecicleLever : MonoBehaviour, IInteractable
{
    [SerializeField] TextMeshProUGUI tutorialText;

    [SerializeField] protected ReciclerTutorial recicler;
    protected Animator animator;

    public UnityAction<IInteractable> onInteractionComplete { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void EndInteraction()
    {

    }

    virtual public void Interact(Interactor interactor, out bool interactionSuccess)
    {
        interactionSuccess = false;
        if (!recicler.IsActive)
        {
            animator.SetTrigger("Open");
            interactionSuccess = true;
            tutorialText.enabled = false;
            recicler.ActivateRecicler();
        }

    }

    public void HasInteracted(Interactor interactor, out bool hasInteracted)
    {
        hasInteracted = recicler.IsActive;
    }
}
