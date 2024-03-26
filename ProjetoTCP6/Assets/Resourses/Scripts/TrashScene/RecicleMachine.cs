using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecicleMachine : MonoBehaviour
{
    [SerializeField] int trashType, amountToComplete;
    [SerializeField] GameObject objectWhenCompleted;

    PlayerScpt player;

    [SerializeField]int currrentAmount;

    private void Start()
    {
        player = GetComponent<PlayerScpt>();
    }

    public void AddCorpse()
    {
        currrentAmount++;

        if(currrentAmount >= amountToComplete)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("A");
        if(other.gameObject.name == IsTrashType(other.gameObject))
        {
            Debug.Log("b");
            AddCorpse();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == IsTrashType(other.gameObject))
        {
            currrentAmount--;
        }
    }

    private string IsTrashType(GameObject trash)
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


