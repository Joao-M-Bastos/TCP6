using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : BaseEnemy
{

    private void Start()
    {
        FindPlayer();
    }
    private void Update()
    {
        MoveFoward();
    }
    public override void OnDie()
    {
        //row new System.NotImplementedException();
    }

    public override void SpecialMove()
    {
        //row new System.NotImplementedException();
    }
}
