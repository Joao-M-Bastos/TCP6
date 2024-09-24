using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    [SerializeField] BoxCollider boxCollider;

    protected int baseDamage;
    string animToTrigger;

    public bool isWeaponActive;

    private void Start()
    {
        baseDamage = weaponData.damage;
        animToTrigger = weaponData.animToTrigger;
    }

    public abstract void ActivateWeapon(Animator handAnimator);

    public abstract void DeactivateWeapon();

    public void ActivateCollider()
    {
        boxCollider.enabled = true;
    }

    public void DeactivateCollider()
    {
        boxCollider.enabled  =false;
        SpecialEffect();
    }

    public void PlayWeaponAnimation(Animator handAnimator)
    {
        handAnimator.SetTrigger(animToTrigger);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BaseEnemy enemy))
        {
            HitOtherCallback();
            enemy.TakeHit(baseDamage);
        }
    }

    public abstract void SpecialEffect();

    public abstract void HitOtherCallback();

}
