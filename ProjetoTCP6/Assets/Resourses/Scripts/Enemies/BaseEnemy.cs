using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] protected int damage;
    [SerializeField] protected float speed, viewDistance, attackDistance;
    [SerializeField] float baseAttackCooldown;

    [SerializeField] BoxCollider attackAreaCollider;

    float attackCooldown, attackAreaActive;
    Transform playerTransform;


    #region Start
    protected void FindPlayer()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    #endregion

    #region Update
    protected void MoveFoward()
    {
        transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));
        
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
            player.TakeAHit(damage);
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
    #endregion


    #region Abstract
    public abstract void SpecialMove();

    public abstract void OnDie();

    public abstract void Attack();
    #endregion
}
