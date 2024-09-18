using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrashEnemy : BaseEnemy
{
    protected float currentCooldown;
    protected bool tired;

    protected int attackDecided;

    public int attackState;

    [SerializeField] protected Animator bodyAnimator;
    [SerializeField] protected Animator enemyAnimator;
    private void Start()
    {
        PlayerFound();
    }

    public void StateController()
    {
        currentCooldown -= Time.deltaTime;

        if (!PlayerFound())
            return;
        
        switch (currentState)
        {
            case EnemyState.Idle:
                DeactivateCollider();
                if (IsThisClose(viewDistance))
                {
                    ChageState(EnemyState.Following);
                    DecideAttack();
                }
                break;

            case EnemyState.Following:
                DeactivateCollider();
                if (IsThisClose(attackDistance + attackDecided))
                    ChageState(EnemyState.Attack);
                else if (IsThisClose(viewDistance))
                    MoveFoward();
                break;

            case EnemyState.Attack:
                if (tired)
                {
                    currentCooldown = 4;
                    ChageState(EnemyState.Resting);
                }

                Attack();

                break;

            case EnemyState.Resting:

                tired = false;
                attackState = 0;

                DeactivateCollider();

                LookAtPlayer();
                transform.position += transform.right * speed * Time.deltaTime;

                if (currentCooldown <= 0 || !IsThisClose(viewDistance))
                    ChageState(EnemyState.Idle);

                break;
        }

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
