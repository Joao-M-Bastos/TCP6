using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RecicleLever : MonoBehaviour, IInteractable
{
    [SerializeField] Recicler recicler;

    public UnityAction<IInteractable> onInteractionComplete { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void EndInteraction()
    {

    }

    public void Interact(Interactor interactor, out bool interactionSuccess)
    {
        interactionSuccess = false;
        if (!recicler.IsActive)
        {
            interactionSuccess = true;
            recicler.ActivateRecicler();
        }

    }
}
