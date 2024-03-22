using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WalkState : PlayerBaseState
{
    public void EndState(PlayerScpt player, PlayerStateController stateController)
    {
        Debug.Log("OutWalkingState");
    }

    public void FixedState(PlayerScpt player, PlayerStateController stateController)
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        player.PlayerRB.AddForce(direction * Time.deltaTime * player.Aceleration, ForceMode.VelocityChange);

        if (direction != Vector3.zero || player.PlayerRB.velocity.magnitude > player.MaxSpeed)
            player.PlayerRB.velocity *= 0.8f;
    }

    public void StartState(PlayerScpt player, PlayerStateController stateController)
    {
        Debug.Log("InWalkingState");
    }

    public void UpdateState(PlayerScpt player, PlayerStateController stateController)
    {
        
    }
}
