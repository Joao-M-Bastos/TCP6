using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BossBehaviour : BaseEnemy
{
    [SerializeField] private BossAttacks[] possibleAttacks;
    [SerializeField] private float restingCooldown;
    [HideInInspector] public bool isAwoke = false;
    [SerializeField] AudioSource hurtSound;
    

    public delegate void BossDeath();
    public static BossDeath bossDeath;

    private int combatLife;
    private int decidedAttack;

    [SerializeField] Slider healthBarSlider;

    protected bool isAttacking;
    

    private void Start()
    {
        SetValues();
        

        TryFindPlayer();
    }

    private void SetValues()
    {
        life = enemyData.life;
        combatLife = life;
        damage = enemyData.damage;
        speed = enemyData.speed;

        UpdateHealthBar();
    }
    
    private void Update()
    {
        RemoveImmunityTime();
    }

    private void FixedUpdate()
    {
        StateController();
    }

    public void AwakeBoss() { isAwoke = true; SetValues();  }
    public void GoToSleep() { isAwoke = false;  }

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
                    restingCooldown -= Time.deltaTime * speed;

                break;

            case EnemyState.Attack:

                if(!isAttacking)
                    DecideAttack();
                

                break;
        }

    }

    private void DecideAttack()
    {
        //Attack(0);
        decidedAttack = Random.Range(0, possibleAttacks.Length);
        Attack(decidedAttack);
    }

    public void Attack(int i)
    {
        possibleAttacks[i].StartAttack(speed, damage, playerTransform, out float restingNeeded);
        this.restingCooldown = restingNeeded;
        isAttacking = true;
    }

    public override void OnDie()
    {
        bossDeath?.Invoke();
    }

    public void FinishAttack()
    {
        isAttacking = false;
        possibleAttacks[decidedAttack].FinishAttack();
        ChageState(EnemyState.Resting);
    }

    public override void Attack()
    {

    }

    public override void OnTakeDamage()
    {
        UpdateHealthBar();
        //hurtSound.Play();
    }

    private void UpdateHealthBar()
    {
        healthBarSlider.value = (float)life / (float)combatLife;
    }
}
