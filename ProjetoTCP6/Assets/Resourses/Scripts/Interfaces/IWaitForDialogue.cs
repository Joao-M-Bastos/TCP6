using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWaitForDialogue
{
    public void DialogueEnded();

    public void WaitForDialogue();

    /*
     * public void DialogueEnded()
    {
        OpenDoor();
        DialogueManager.dialogueEnd -= DialogueEnded;
    }

    public void WaitForDialogue()
    {
        DialogueManager.dialogueEnd += DialogueEnded;
    }
    */
}
