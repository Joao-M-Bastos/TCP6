using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossJumpAttack : BossAttacks
{
    [SerializeField] float attackRange;
    [SerializeField] LayerMask playerMask;
    [SerializeField] ParticleSystem buildUpParticules;

    public override void PlayAnimation()
    {
        bossAnimator.SetTrigger("JumpAttack");
        buildUpParticules.Play();
    }

    public void CheckJumpCollision()
    {
        RaycastHit[] hit = Physics.SphereCastAll(this.transform.position,attackRange, transform.forward,attackRange ,playerMask);
        
        if(hit.Length > 0)
        {
            PlayerScpt player = hit[0].transform.gameObject.GetComponent<PlayerScpt>();

            player.TakeAHit(damageModifier + attackDamage);
            player.TakeKnockBack(this.transform.position);
        }
    }

    public override void FinishAttack()
    {
        buildUpParticules.Stop();
    }
}
