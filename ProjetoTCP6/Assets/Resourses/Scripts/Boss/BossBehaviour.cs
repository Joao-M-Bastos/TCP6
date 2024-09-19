using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BossBehaviour : BaseEnemy
{
    [SerializeField] private BossAttacks[] possibleAttacks;
    [SerializeField] private float restingCooldown;
    [HideInInspector] public bool isAwoke = false;
    [SerializeField] AudioSource hurtSound;

    private int combatLife;

    [SerializeField] GameObject healthBarCanva;
    [SerializeField] Slider healthBarSlider;

    protected bool isAttacking;

    private void Start()
    {
        SetValues();
        

        TryFindPlayer();
    }

    private void SetValues()
    {
        life = enemyData.life + RecicleCounter.instance.RecicleCount;
        combatLife = life;
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

    public void AwakeBoss() { isAwoke = true; SetValues(); healthBarCanva.SetActive(true); }
    public void GoToSleep() { isAwoke = false; healthBarCanva.SetActive(false); }

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
        Attack(Random.Range(0, possibleAttacks.Length));
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

    public override void OnTakeDamage()
    {
        UpdateHealthBar();
        hurtSound.Play();
    }

    private void UpdateHealthBar()
    {
        healthBarSlider.value = (float)life / (float)combatLife;
    }
}
