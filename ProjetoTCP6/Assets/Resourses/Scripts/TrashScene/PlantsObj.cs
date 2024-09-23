using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsObj : Plants
{

    protected override void ChangeState(int levelID)
    {
        for (int i = 0; i < plantsLevel.Length; i++)
        {
            if (i == levelID)
            {
                plantsLevel[i].gameObject.SetActive(true);
                return;
            }
            plantsLevel[i].gameObject.SetActive(false);
        }
    }
}
