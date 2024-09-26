using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitProjectile : MonoBehaviour
{
    int bulletDamage;
    public void Inicialize(float speed, int damage)
    {
        bulletDamage = damage;
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void Update()
    {
        if (transform.position.y < 0)
            Destroy(this.gameObject);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerScpt>().TakeAHit(bulletDamage);
            other.GetComponent<PlayerScpt>().TakeKnockBack(this.transform.position);
        }
        Destroy(gameObject);
    }
}
