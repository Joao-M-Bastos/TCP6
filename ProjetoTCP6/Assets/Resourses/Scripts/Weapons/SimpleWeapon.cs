using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWeapon : BaseWeapon
{
    private void Update()
    {
        ReduceTimer();
    }

    public override void HitOtherCallback()
    {
        //throw new System.NotImplementedException();
    }

    public override void SpecialEffect()
    {
        //throw new System.NotImplementedException();
    }
}
