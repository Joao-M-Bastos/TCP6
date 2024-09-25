using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static RecicleCounter;

public class RecicleCounter : MonoBehaviour
{
    public delegate void OnRecicleCountChange();
    public static OnRecicleCountChange onRecicleCountChange;

    public static RecicleCounter instance;
    [SerializeField] int startRecicleAmount = 10;
    int recicleAmount;
    int paperAmount, plasticAmount, glassAmount, metalAmount;

    public int RecicleCount => recicleAmount;

    private void Awake()
    {
        recicleAmount = startRecicleAmount;

        if (instance == null)
            instance = this;
    }



    public void RemoveRecicleAmount()
    {
        if (recicleAmount > 0)
        {
            recicleAmount--;
            onRecicleCountChange?.Invoke();
        }
    }

    public void AddRecicleAmount()
    {
        recicleAmount++;
        onRecicleCountChange?.Invoke();
    }
}
