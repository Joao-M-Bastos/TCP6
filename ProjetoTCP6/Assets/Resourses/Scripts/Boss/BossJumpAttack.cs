using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossJumpAttack : BossAttacks
{
    [SerializeField] float attackRange;
    [SerializeField] LayerMask playerMask;
    public override void PlayAnimation()
    {
        bossAnimator.SetTrigger("JumpAttack");
    }

    public void CheckJumpCollision()
    {
        RaycastHit[] hit = Physics.SphereCastAll(this.transform.position,attackRange, transform.forward,attackRange ,playerMask);
        
        if(hit.Length > 0)
        {
            PlayerScpt player = hit[0].transform.gameObject.GetComponent<PlayerScpt>();

            player.TakeAHit(damageModifier + attackDamage);
        }
    }
}
