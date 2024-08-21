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
        Walk(player, stateController);
    }

    private void Walk(PlayerScpt player, PlayerStateController stateController)
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;


        player.PlayerRB.AddForce(direction * Time.deltaTime * player.Aceleration, ForceMode.VelocityChange);

        if (direction == Vector3.zero || player.PlayerRB.velocity.magnitude > player.MaxSpeed)
            player.PlayerRB.velocity *= 0.8f;

        Vector3 input = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerPosition = player.transform.position;

        player.transform.LookAt(new Vector3(input.x, playerPosition.y, input.z + 4));
    }

    public void StartState(PlayerScpt player, PlayerStateController stateController)
    {
        //Debug.Log("InWalkingState");
    }

    public void UpdateState(PlayerScpt player, PlayerStateController stateController)
    {
        if (Input.GetMouseButtonDown(0))
        {
            player.RightHand.ActivateSword();
        }
    }
}
