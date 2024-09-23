using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossAttacks : MonoBehaviour
{
    public float restingTimeNedded;

    [SerializeField] protected int attackDamage;
    protected int damageModifier;
    protected float speedModifier;

    protected Transform playerTransform;
    protected Animator bossAnimator;

    public void Awake()
    {
        bossAnimator = GetComponent<Animator>();
    }

    public void StartAttack(float speed, int damage, Transform playerTransform, out float restingTime)
    {
        damageModifier = damage;
        speedModifier = speed;

        this.playerTransform = playerTransform;

        restingTime = this.restingTimeNedded;
        
        PlayAnimation();
    }

    virtual public void FinishAttack()
    {

    }

    public abstract void PlayAnimation();

}
