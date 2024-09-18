using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public Transform interacionPoint;
    public LayerMask interacionLayer;
    public float interactionPointRatios = 1f;
    public bool isInteraction{  get; private set; }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(interacionPoint.position, interactionPointRatios, interacionLayer);

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                IInteractable interactable = colliders[i].GetComponent<IInteractable>();

                if (interactable != null)
                    StartInteraction(interactable);
            }
        }
    }

    private void StartInteraction(IInteractable interactable)
    {
        interactable.Interact(this, out bool interctionSuccessful);
        isInteraction = true;
    }

    public void EndInteraction()
    {
        isInteraction = false;
    }
}
