using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticEnemy : TrashEnemy
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
                currentCooldown = 0.3f;
                attackState = 1;
                break;
            case 1:
                rb.AddForce(transform.forward * 5, ForceMode.VelocityChange);
                ActiveAttackCollider(0.2f);
                currentCooldown = 0.5f;
                attackState = 2;
                break;
            case 2:
                tired = true;
                break;
        }
    }

    public override void StrongAttack()
    {

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
