using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GaiaTips : MonoBehaviour, IInteractable
{
    DialogueTrigger dialogueTrigger;

    public UnityAction<IInteractable> onInteractionComplete { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    private void Awake()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }
    public void EndInteraction()
    {

    }

    public void HasInteracted(Interactor interactor, out bool hasInteracted)
    {
        hasInteracted = false;
    }

    public void Interact(Interactor interactor, out bool interactionSuccess)
    {
        //SetRandomText();
        if (DialogueManager.Instance.InDialog)
        {
            interactionSuccess = false;
            return;
        }
        dialogueTrigger.TriggerDialogueEvent();
        interactionSuccess = true;
    }
}
