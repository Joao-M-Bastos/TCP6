using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossBehaviour : BaseEnemy
{
    [SerializeField] private BossAttacks[] possibleAttacks;
    [SerializeField] private float restingCooldown;
    [HideInInspector] public bool isAwoke = false;

    protected bool isAttacking;

    private void Start()
    {
        SetValues();
        

        TryFindPlayer();
    }

    private void SetValues()
    {
        life = enemyData.life + RecicleCounter.instance.RecicleCount;
        damage = enemyData.damage + (int)(RecicleCounter.instance.RecicleCount / 2);
        speed = 1 + (int)(RecicleCounter.instance.RecicleCount / 10);
    }

    private void Update()
    {
        RemoveImmunityTime();
    }

    private void FixedUpdate()
    {
        StateController();
    }

    public void AwakeBoss() { isAwoke = true; SetValues(); }
    public void GoToSLeed() { isAwoke = false; }

    public void StateController()
    {
        if(!isAwoke)
            ChageState(EnemyState.Idle);

        switch (currentState)
        {
            case EnemyState.Idle:
                if (isAwoke)
                    ChageState(EnemyState.Resting);
                
                break;
            case EnemyState.Resting:

                if (restingCooldown <= 0)
                    ChageState(EnemyState.Attack);
                else
                    restingCooldown -= Time.deltaTime;

                break;

            case EnemyState.Attack:

                if(!isAttacking)
                    DecideAttack();
                

                break;
        }

    }

    private void DecideAttack()
    {
        Attack(0);
        //Attack(Random.Range(0, possibleAttacks.Length));
    }

    public void Attack(int i)
    {
        possibleAttacks[i].StartAttack(speed, damage, playerTransform, out float restingNeeded);
        this.restingCooldown = restingNeeded;
        isAttacking = true;
    }

    public override void OnDie()
    {

    }

    public void FinishAttack()
    {
        isAttacking = false;
        ChageState(EnemyState.Resting);
    }

    public override void Attack()
    {

    }
}
