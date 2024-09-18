using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalEnemy : TrashEnemy
{
    private void Update()
    {
        RemoveImmunityTime();
    }

    private void FixedUpdate()
    {
        StateController();
    }
    public override void OnDie()
    {
        DropItemOnDeath();
        PlayParticuleOnDeath();
    }

    public override void QuickAttack()
    {

        switch (attackState)
        {
            case 0:
                currentCooldown = 0.5f;
                attackState = 1;
                break;
            case 1:
                rb.AddForce(transform.forward, ForceMode.VelocityChange);
                ActiveAttackCollider(0.5f);
                currentCooldown = 0.5f;
                attackState = 2;
                break;
            case 2:
                tired = true;
                break;
        }
    }

    public override void SpecialMove()
    {
        //throw new System.NotImplementedException();
    }

    public override void StrongAttack()
    {
        if (currentCooldown > 0)
            return;

        switch (attackState)
        {
            case 0:
                currentCooldown = 0.5f;
                attackState = 1;
                break;
            case 1:
                AddToDamage(1);
                ActiveAttackCollider(0.5f);
                currentCooldown = 1f;
                attackState = 2;
                break;
            case 2:
                AddToDamage(0);
                tired = true;
                break;
        }
    }
}
