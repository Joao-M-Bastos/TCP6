using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseWeapon;

public class DamageCollider : MonoBehaviour
{
    float cooldown;
    int damage;

    private void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
                Destroy(gameObject);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BaseEnemy enemy))
        {
            enemy.TakeHit(damage);
        }
    }

    public void SetCollider(float _cooldown, int _damage)
    {
        cooldown = _cooldown;
        damage = _damage;
    }

}
