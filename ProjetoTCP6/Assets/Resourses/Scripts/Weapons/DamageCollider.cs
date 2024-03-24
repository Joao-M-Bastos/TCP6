using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseWeapon;

public class DamageCollider : MonoBehaviour
{
    float cooldown;

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
            enemy.KillEnemy();
        }
    }

    public void SetCooldown(float value)
    {
        cooldown = value;
    }

}
