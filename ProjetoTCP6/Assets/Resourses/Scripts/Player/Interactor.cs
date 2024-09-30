using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] GameObject pressE;
    public Transform interacionPoint;
    public LayerMask interacionLayer;
    public float interactionPointRatios = 1f;
    public bool isInteraction{  get; private set; }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(interacionPoint.position, interactionPointRatios, interacionLayer);

        bool activatePressE = false;

        if(colliders.Length> 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                IInteractable interactable = colliders[i].GetComponent<IInteractable>();

                interactable.HasInteracted(this, out bool hasInteracted);

                if (!hasInteracted)
                    activatePressE =true;
            }
        }

        pressE.SetActive(activatePressE);

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
