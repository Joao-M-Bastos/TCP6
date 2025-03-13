using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCollider : MonoBehaviour
{

    [SerializeField] GameObject wait;
    bool hasCollided;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasCollided){
            GetComponent<DialogueTrigger>().TriggerDialogueEvent();
            hasCollided = true;
            if(wait != null && wait.TryGetComponent(out IWaitForDialogue waitScript))
                waitScript.WaitForDialogue();
        }
    }
}
