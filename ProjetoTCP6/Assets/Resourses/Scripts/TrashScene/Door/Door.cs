using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] int keyNeeded;
    bool isOpend;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        isOpend = false;
    }

    public void TryOpenDoor()
    {
        if (isOpend)
            return;

        Inventory inventory = FindAnyObjectByType<Inventory>();

        if (keyNeeded <= 0 || inventory.HasItem(keyNeeded))
        {
            animator.SetBool("Open", true);
            isOpend = true;
            inventory.RemoveItem(keyNeeded);
        } 
    }

    public override void Interact()
    {
        TryOpenDoor();
    }
}
