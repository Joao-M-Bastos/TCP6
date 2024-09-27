using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialDoor : MonoBehaviour, IWaitForDialogue
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        DialogueManager.dialogueEnd -= DialogueEnded;
    }

    public void CloseDoor()
    {
        animator.SetBool("Open", false);
    }

    public void OpenDoor()
    {
        animator.SetBool("Open", true);
    }

    public void DialogueEnded()
    {
        OpenDoor();
        DialogueManager.dialogueEnd -= DialogueEnded;
    }

    public void WaitForDialogue()
    {
        DialogueManager.dialogueEnd += DialogueEnded;
    }
}
