using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WalkState : PlayerBaseState
{
    public void EndState(PlayerScpt player, PlayerStateController stateController)
    {
        Debug.Log("InWalkingState");
    }

    public void FixedState(PlayerScpt player, PlayerStateController stateController)
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        player.PlayerRB.AddForce(direction * Time.deltaTime);
    }

    public void StartState(PlayerScpt player, PlayerStateController stateController)
    {

    }

    public void UpdateState(PlayerScpt player, PlayerStateController stateController)
    {
        Debug.Log("OutWalkingState");
    }
}
