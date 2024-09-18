using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BossMorterAttack : BossAttacks
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] BossAim aim;

    public override void PlayAnimation()
    {
        bossAnimator.SetTrigger("MorterAttack");
    }

    public void ShootMorter()
    {
        if (aim.PlayerTransform == null)
            return;

        GameObject morterTarget = Instantiate(projectilePrefab, aim.PlayerTransform.position - (Vector3.up* aim.PlayerTransform.position.y), Quaternion.identity);

        morterTarget.GetComponent<BossMorterTarget>().Inicialize(bulletSpeed * speedModifier, damageModifier + attackDamage);
    }
}
