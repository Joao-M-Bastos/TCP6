using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IInteractable
{
    public UnityAction<IInteractable> onInteractionComplete { get; set; }

    public void Interact(Interactor interactor, out bool interactionSuccess);

    public void EndInteraction();

    public void HasInteracted(Interactor interactor, out bool hasInteracted);
}
