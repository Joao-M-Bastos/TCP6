using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private int dialogueEventIndex;
    [SerializeField] private int cameraWork;
    [field: SerializeField] public List<DialogueEvent> DialogueEvents { get; private set; }
    int currentDialogue;

    public void TriggerDialogueEvent()
    {
        if (dialogueEventIndex >= 0)
            DialogueManager.Instance.StartDialogue(dialogueEventIndex, cameraWork);
        else
        {
            DialogueManager.Instance.StartDialogue(DialogueEvents[currentDialogue].Dialogues, cameraWork);
            currentDialogue++;

            if(currentDialogue == DialogueEvents.Count)
                currentDialogue = 0;
        }
    }
}
