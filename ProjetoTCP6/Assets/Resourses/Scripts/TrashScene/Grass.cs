using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class Grass : Plants
{
    
    [SerializeField] protected Material[] materialLevel;

    protected override void ChangeState(int materialID)
    {
        for (int i = 0; i < plantsLevel.Length; i++)
        {
            plantsLevel[i].GetComponent<MeshRenderer>().material = materialLevel[materialID];
        }
    }
}
