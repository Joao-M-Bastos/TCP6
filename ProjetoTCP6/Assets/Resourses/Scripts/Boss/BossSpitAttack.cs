using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpitAttack : BossAttacks
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] BossAim aim;

    public override void PlayAnimation()
    {
        bossAnimator.SetTrigger("SpitAttack");
    }

    public void ShootSpit()
    {
        if (aim.PlayerTransform == null)
            return;

        GameObject spitSprojectile = Instantiate(projectilePrefab, aim.transform.position, aim.transform.rotation);

        spitSprojectile.GetComponent<SpitProjectile>().Inicialize(bulletSpeed * speedModifier, damageModifier + attackDamage);
    }
}
