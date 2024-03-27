using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperEnemy : TrashEnemy
{
    private void Start()
    {
        FindPlayer();
    }
    private void Update()
    {
        if (IsThisClose(attackDistance) && IsCooldownZero())
            Attack();
        else if(IsThisClose(viewDistance))
            MoveFoward();

    }
    public override void Attack()
    {
        ActiveAttackCollider();
    }

    public override void OnDie()
    {
        GenerateCorpse();
    }

    public override void SpecialMove()
    {
        //throw new System.NotImplementedException();
    }
}
