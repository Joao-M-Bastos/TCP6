using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : BaseEnemy
{

    private void Start()
    {
        TryFindPlayer();
    }
    private void Update()
    {
        MoveFoward();
        if(IsCooldownZero() && IsThisClose(attackDistance))
        {
            Attack();
        }
    }
    public override void OnDie()
    {
        //row new System.NotImplementedException();
    }

    public override void SpecialMove()
    {
        //row new System.NotImplementedException();
    }

    public override void Attack()
    {
        ActiveAttackCollider();
    }
}
