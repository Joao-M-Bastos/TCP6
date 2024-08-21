using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWeapon : BaseWeapon
{
    public override void ActivateSword()
    {
        //if (currentCooldown <= 0)
           ActivateCollider();
        //}

        //Gizmos.DrawCube(boxStartPoint.transform.position + boxStartPoint.transform.forward, new Vector3(currentSize, currentSize, currentSize) * 2);
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
