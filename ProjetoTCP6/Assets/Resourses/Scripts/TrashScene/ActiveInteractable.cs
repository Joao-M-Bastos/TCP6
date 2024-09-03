using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInteractable : MonoBehaviour
{
    [SerializeField] Interactable interaction;
    bool hasPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasPlayer = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hasPlayer)
        {
            interaction.Interact();
        }
    }
}
