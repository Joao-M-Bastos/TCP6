using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_WalkState : PlayerBaseState
{
    public void EndState(PlayerScpt player, PlayerStateController stateController)
    {
        Debug.Log("OutWalkingState");
    }

    public void FixedState(PlayerScpt player, PlayerStateController stateController)
    {
        player.Walk();
        player.LookAtMouse();
    }

    public void StartState(PlayerScpt player, PlayerStateController stateController)
    {
        //Debug.Log("InWalkingState");
    }

    public void UpdateState(PlayerScpt player, PlayerStateController stateController)
    {
        if (Input.GetMouseButtonDown(0))
        {
            player.Attack(out bool attacked);
        }
    }
}
