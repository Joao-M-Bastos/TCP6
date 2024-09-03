using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    public EnemyData enemyData;
    protected EnemyBaseState currentState;
    protected EnemyBaseState idleState = new EnemyIdleState();
    protected EnemyBaseState currentState;
    protected EnemyBaseState currentState;
    protected EnemyBaseState currentState;

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
    Transform playerTransform;

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
        if (playerTransform == null)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerScpt player))
        {
            attackAreaCollider.enabled = false;
            player.TakeAHit(damage + addToDamage);
        }
    }

    #endregion

    #region Actions

    public void ActiveAttackCollider()
    {
        attackAreaCollider.enabled = true;
        attackAreaActive = 0.2f;
        attackCooldown = baseAttackCooldown;
    }
    public void ActiveAttackCollider(float extraActiveTime)
    {
        attackAreaCollider.enabled = true;
        attackAreaActive = 0.2f + extraActiveTime;
        attackCooldown = baseAttackCooldown;
    }

    public void TakeHit(int damage)
    {
        TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
            Die();
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
    
    public void ChageState(EnemyBaseState newState)
    {
        currentState = newState;
    }

    #endregion

    #region Abstract
    public abstract void SpecialMove();

    public abstract void OnDie();

    public abstract void Attack();
    #endregion
}
