using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerBaseState
{
    public void StartState(PlayerScpt player, PlayerStateController stateController);

    public void UpdateState(PlayerScpt player, PlayerStateController stateController);

    public void FixedState(PlayerScpt player, PlayerStateController stateController);

    public void EndState(PlayerScpt player, PlayerStateController stateController);

}
