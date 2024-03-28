using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWeapon : BaseWeapon
{
    public override void ActivateSword()
    {
        if (currentCooldown <= 0)
        {
            ActivateCollider();
        }
    }

    public override void HitOtherCallback()
    {
        //throw new System.NotImplementedException();
    }

    public override void SpecialEffect()
    {
        //throw new System.NotImplementedException();
    }

    public override void UpdateFrame()
    {
        ReduceTimer();
    }
}
