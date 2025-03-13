using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private int dialogueEventIndex;
    [SerializeField] private int cameraWork;

    public void TriggerDialogueEvent()
    {
        DialogueManager.Instance.StartDialogue(dialogueEventIndex, cameraWork);
    }
}
