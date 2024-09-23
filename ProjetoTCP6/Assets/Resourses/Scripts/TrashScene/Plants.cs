using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RecicleCounter;

public abstract class Plants : MonoBehaviour
{
    protected float startValue;
    [SerializeField] protected GameObject[] plantsLevel;
    [SerializeField] protected float mediumPorcentage, alivePorcentage;

    protected void Start()
    {
        startValue = RecicleCounter.instance.RecicleCount;
        UpdateFloralStatus();
    }
    protected void OnEnable()
    {
        onRecicleCountChange += UpdateFloralStatus;
    }

    protected void OnDisable()
    {
        onRecicleCountChange -= UpdateFloralStatus;
    }

    public void UpdateFloralStatus()
    {
        float value = RecicleCounter.instance.RecicleCount;

        float percentage = value / startValue;

        if (percentage > mediumPorcentage)
            ChangeState(0);
        else if(percentage > alivePorcentage)
            ChangeState(1);
        else
            ChangeState(2); 
    }

    protected abstract void ChangeState(int levelID);
}
