using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_DamageState : PlayerBaseState
{
    float recoverTime;

    public void EndState(PlayerScpt player, PlayerStateController stateController)
    {

    }

    public void FixedState(PlayerScpt player, PlayerStateController stateController)
    {
        
    }

    public void StartState(PlayerScpt player, PlayerStateController stateController)
    {
        recoverTime = 1;
    }

    public void UpdateState(PlayerScpt player, PlayerStateController stateController)
    {
        recoverTime -= Time.deltaTime;

        if (recoverTime < 0)
            stateController.ChangeState(stateController.walkState);
    }
}
