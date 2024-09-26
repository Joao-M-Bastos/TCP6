using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Idle,
    Following,
    Attack,
    Resting
}

public abstract class BaseEnemy : MonoBehaviour
{
    public EnemyData enemyData;

    protected EnemyState currentState;

    protected int life;
    protected int damage;
    protected float speed, viewDistance, attackDistance;
    protected float baseAttackCooldown;

    protected int addToDamage;

    [SerializeField] GameObject deathParticule;

    [SerializeField] BoxCollider attackAreaCollider;
    protected Rigidbody rb;
    DropItem dropItemOnDeath;

    float attackCooldown, attackAreaActive;
    protected Transform playerTransform;

    float immunityTime = 0.5f;

    private void Awake()
    {
        dropItemOnDeath = GetComponent<DropItem>();
        rb = GetComponent<Rigidbody>();

        life = enemyData.life;
        damage = enemyData.damage;
        speed = enemyData.speed;
        viewDistance = enemyData.viewDistance;
        attackDistance = enemyData.attackDistance;
        baseAttackCooldown = enemyData.baseAttackCooldown;
    }

    #region Start
    protected void TryFindPlayer()
    {
        if (playerTransform == null && GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }

    #endregion

    #region Update

    protected void LookAtPlayer()
    {
        transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));
    }
    protected void MoveFoward()
    {
        LookAtPlayer();
        
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    protected void RemoveDamageArea()
    {
        if(attackAreaActive > 0)
            attackAreaActive -= Time.deltaTime;
        else
            attackAreaCollider.enabled = false;
    }

    protected void RemoveImmunityTime()
    {
        if(immunityTime > 0)
            immunityTime -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerScpt player))
        {
            attackAreaCollider.enabled = false;
            player.TakeAHit(damage + addToDamage);
            player.TakeKnockBack(this.transform.position);
        }
    }

    #endregion

    #region Actions

    public void ActiveAttackCollider()
    {
        attackAreaCollider.enabled = true;
        attackCooldown = baseAttackCooldown;
    }

    public void DeactivateCollider()
    {
        attackAreaCollider.enabled = false;
    }

    public void TakeHit(int damage)
    {
        if(immunityTime <= 0)
            TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        
        life -= damage;
        immunityTime = 0.5f;
        if (life <= 0)
            Die();

        OnTakeDamage();
    }

    public void Die()
    {
        OnDie();
        Destroy(this.gameObject);
    }

    public void AddToDamage(int addToDmg)
    {
        addToDamage = addToDmg;
    }

    #endregion

    #region Verifications

    public bool IsCooldownZero()
    {
        if(attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
            return false;
        }
        return true;
    }

    public bool IsInDirectLiveOfSight()
    {
        Debug.DrawLine(transform.position, playerTransform.position);
        if (Physics.Raycast(transform.position, playerTransform.position- transform.position, out RaycastHit hitInfo))
        {
            return hitInfo.collider.gameObject.CompareTag("Player");
        }
        else
            return false;
    }

    public bool IsThisClose(float value)
    {
        return DistanceFromPlayer() < value;
    }

    public float DistanceFromPlayer()
    {
        return Vector3.Distance(transform.position, playerTransform.position);
    }

    public bool PlayerFound()
    {
        if(playerTransform != null)
            return true;

        TryFindPlayer();
        return false;
    }

    #endregion

    #region OnDeath
    public void DropItemOnDeath()
    {
        if(dropItemOnDeath != null)
            dropItemOnDeath.DropItemCall();
    }

    public void PlayParticuleOnDeath()
    {
        Instantiate(deathParticule, this.transform.position, deathParticule.transform.rotation);
    }

    #endregion

    #region State
    
    public void ChageState(EnemyState newState)
    {
        currentState = newState;
    }

    #endregion

    #region Abstract

    public abstract void OnDie();
    public abstract void OnTakeDamage();

    public abstract void Attack();
    #endregion
}
