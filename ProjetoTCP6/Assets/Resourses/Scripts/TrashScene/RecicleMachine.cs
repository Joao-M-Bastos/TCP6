using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecicleMachine : MonoBehaviour
{
    [SerializeField] int trashType, amountToComplete;
    [SerializeField] int objectWhenCompleted;

    PlayerScpt player;

    [SerializeField]int currentAmount;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScpt>();
    }

    public void AddCorpse()
    {
        currentAmount++;

        if(currentAmount >= amountToComplete)
        {
            player.RightHand.SetSword(objectWhenCompleted);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains(IsTrashType()))
        {
            AddCorpse();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains(IsTrashType()))
        {
            currentAmount--;
        }
    }

    private string IsTrashType()
    {
        string correctName = "";

        switch (trashType)
        {
            case 0:
                correctName = "Corpse_PaperTrash";
                break;
        }

        return correctName;
    }
}


