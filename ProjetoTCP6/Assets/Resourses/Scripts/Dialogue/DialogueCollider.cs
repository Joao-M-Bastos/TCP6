using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCollider : MonoBehaviour
{

    [SerializeField] TutorialDoor door;
    bool hasCollided;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasCollided){
            GetComponent<DialogueTrigger>().TriggerDialogueEvent();
            hasCollided = true;
            door.WaitForDialogue();
        }
    }
}
