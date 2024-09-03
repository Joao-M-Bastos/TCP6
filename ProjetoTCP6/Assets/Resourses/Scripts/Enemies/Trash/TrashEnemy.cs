using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrashEnemy : BaseEnemy
{
    protected float currentCooldown;
    protected bool tired;

    protected int attackDecided;

    public int attackState;
    private void Start()
    {
        PlayerFound();
    }

    public void StateController()
    {
        currentCooldown -= Time.deltaTime;

        if (!PlayerFound())
            return;
        /*
        switch (currentState)
        {
            case EnemyBaseState.Idle:
                if (IsThisClose(viewDistance))
                {
                    ChageState(EnemyBaseState.Following);
                    DecideAttack();
                }
                break;

            case EnemyBaseState.Following:

                if (IsThisClose(attackDistance + attackDecided))
                    ChageState(EnemyBaseState.Attack);
                else if (IsThisClose(viewDistance))
                    MoveFoward();
                break;

            case EnemyBaseState.Attack:
                if (tired)
                {
                    currentCooldown = 4;
                    ChageState(EnemyBaseState.Resting);
                }

                Attack();

                break;

            case EnemyBaseState.Resting:

                tired = false;
                attackState = 0;

                LookAtPlayer();
                transform.position += transform.right * speed * Time.deltaTime;

                if (currentCooldown <= 0)
                    ChageState(EnemyBaseState.Idle);

                break;
        }

        */
    }

    public override void Attack()
    {
        if (currentCooldown > 0 && attackState != 0)
            return;

        if (attackDecided == 0)
            StrongAttack();
        else
            QuickAttack();
        
    }

    public abstract void StrongAttack();

    public abstract void QuickAttack();

    protected void DecideAttack()
    {
        attackDecided = Random.Range(0, 2);
    }
}
