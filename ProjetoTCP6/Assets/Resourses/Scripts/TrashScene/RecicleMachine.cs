using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecicleMachine : MonoBehaviour
{
    [SerializeField] int trashType, amountToComplete;
    [SerializeField] GameObject objectWhenCompleted;

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

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.gameObject.name == IsTrashType(other.gameObject))
        {
            AddCorpse();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == IsTrashType(other.gameObject))
        {
            currentAmount--;
        }
    }

    private string IsTrashType(GameObject trash)
    {
        string correctName = "";

        switch (trashType)
        {
            case 0:
                correctName = "Corpse_PaperTrash(Clone)";
                break;
        }

        return correctName;
    }
}


