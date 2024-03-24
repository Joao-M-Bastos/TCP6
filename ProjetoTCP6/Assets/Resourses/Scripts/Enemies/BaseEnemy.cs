using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int life, damage;
    Transform playerTransform;

    protected void FindPlayer()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    protected void MoveFoward()
    {
        transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));
        
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public abstract void SpecialMove();

    public abstract void OnDie();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerScpt player))
        {
            player.TakeAHit(1);
        }
    }

    public void KillEnemy()
    {
        Die();
    }

    public void Die()
    {
        OnDie();
        Destroy(this.gameObject);
    }

    public float DistanceFromPlayer()
    {
        return Vector3.Distance(transform.position, playerTransform.position);
    }

}
