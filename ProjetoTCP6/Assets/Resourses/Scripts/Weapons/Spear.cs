using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : BaseWeapon
{
    public override void ActivateWeapon(Animator handAnimator)
    {
        isWeaponActive = true;
        PlayWeaponAnimation(handAnimator);
    }

    public override void DeactivateWeapon()
    {
        isWeaponActive = false;
    }

    public override void HitOtherCallback()
    {
    }

    public override void SpecialEffect()
    {
    }
}
