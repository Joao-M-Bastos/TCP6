using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSlayerProjectile : MonoBehaviour
{
    int bulletDamage;
    public void Inicialize(float speed, int damage)
    {
        bulletDamage = damage;
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.TryGetComponent(out BaseEnemy enemy))
            enemy.TakeDamage(bulletDamage);

        Destroy(gameObject);
    }
}
