using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RecicleCounter : MonoBehaviour
{
    public static RecicleCounter instance;
    [SerializeField] int startRecicleAmount = 10;
    int recicleAmount;

    public int RecicleCount => recicleAmount;

    private void Awake()
    {
        recicleAmount = startRecicleAmount;

        if (instance == null)
            instance = this;
    }



    public void RemoveRecicleAmount()
    {
        if(recicleAmount > 1)
            recicleAmount--;
    }

    public void AddRecicleAmount()
    {
        recicleAmount++;
    }
}
