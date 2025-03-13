using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWhenDialogueEnd : MonoBehaviour, IWaitForDialogue
{
    [SerializeField] GameObject objectToActivate;
    public void DialogueEnded()
    {
        objectToActivate.SetActive(true);
    }

    public void WaitForDialogue()
    {
        DialogueManager.dialogueEnd += DialogueEnded;
    }
}
