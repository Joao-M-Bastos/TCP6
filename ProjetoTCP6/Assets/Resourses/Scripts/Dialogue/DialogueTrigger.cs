using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private int dialogueEventIndex;

    public void TriggerDialogueEvent()
    {
        DialogueManager.Instance.StartDialogue(DialogueManager.Instance.DialogueEvents[dialogueEventIndex].Dialogues);
    }
}
