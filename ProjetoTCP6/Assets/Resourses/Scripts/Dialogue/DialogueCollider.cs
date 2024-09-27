using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCollider : MonoBehaviour
{
    bool hasCollided;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasCollided){
            GetComponent<DialogueTrigger>().TriggerDialogueEvent();
            hasCollided = true;
        }
    }
}
