using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassEnemy : TrashEnemy
{
    [SerializeField] AudioSource deathSound;
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
        deathSound.Play();
    }

    public override void QuickAttack()
    {
        switch (attackState)
        {
            case 0:
                enemyAnimator.SetTrigger("BuildUp");
                currentCooldown = 1f;
                attackState = 1;
                break;
            case 1:
                enemyAnimator.SetTrigger("Attacking");
                rb.AddForce(transform.forward * 4, ForceMode.VelocityChange);
                ActiveAttackCollider();
                currentCooldown = 0.5f;
                attackState = 2;
                break;
            case 2:
                enemyAnimator.SetTrigger("Idle");
                tired = true;
                break;
        }
    }

    public override void StrongAttack()
    {

        switch (attackState)
        {
            case 0:
                enemyAnimator.SetTrigger("BuildUp");
                currentCooldown = 0.5f;
                attackState = 1;
                break;
            case 1:
                AddToDamage(1);
                enemyAnimator.SetTrigger("Attacking");
                ActiveAttackCollider();
                currentCooldown = 1f;
                attackState = 2;
                break;
            case 2:
                enemyAnimator.SetTrigger("Idle");
                AddToDamage(0);
                tired = true;
                break;
        }
    }

    public override void OnTakeDamage()
    {
        FlashRender();

        if(currentState == EnemyState.Resting && Random.Range(0, 2) == 1)
            ChageState(EnemyState.Following);   
    }
}
