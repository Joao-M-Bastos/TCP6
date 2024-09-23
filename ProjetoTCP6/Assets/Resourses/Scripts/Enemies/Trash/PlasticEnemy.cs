using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticEnemy : TrashEnemy
{
    [SerializeField] GameObject[] variations;
    [SerializeField] AudioSource deathSound;

    private void Start()
    {
        variations[Random.Range(0, 2)].SetActive(false);
        PlayerFound();
    }
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
                currentCooldown = 0.4f;
                attackState = 1;
                break;
            case 1:
                enemyAnimator.SetTrigger("Attacking");
                rb.AddForce(transform.forward * 5, ForceMode.VelocityChange);
                ActiveAttackCollider();
                currentCooldown = 1f;
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
                enemyAnimator.SetTrigger("Attacking");
                AddToDamage(1);
                ActiveAttackCollider();
                currentCooldown = 0.5f;
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

        if (currentState == EnemyState.Resting && Random.Range(0,2) == 1)
            ChageState(EnemyState.Following);
    }
}
