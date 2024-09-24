using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSlayer : BaseWeapon
{
    [SerializeField] GameObject slayerProjectile;
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
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject projectile = Instantiate(slayerProjectile, playerTransform.position + (playerTransform.forward * 2), playerTransform.rotation);
        projectile.GetComponent<DragonSlayerProjectile>().Inicialize(20, 1);
    }
}
