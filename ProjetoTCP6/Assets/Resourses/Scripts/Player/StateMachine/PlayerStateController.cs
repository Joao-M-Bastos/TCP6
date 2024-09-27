using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    PlayerScpt player;
    PlayerBaseState currentState;

    public PlayerBaseState CurrentState => currentState;

    public PlayerBaseState walkState = new Player_WalkState();
    public PlayerBaseState damageState = new Player_DamageState();

    private void Awake()
    {
        player = GetComponent<PlayerScpt>();
    }


    void Start()
    {
        currentState = walkState;
        currentState.StartState(player, this);
    }

    public void ChangeState(PlayerBaseState newState)
    {
        currentState.EndState(player, this);

        currentState = newState;

        currentState.StartState(player, this);
    }


    void Update()
    {
        currentState.UpdateState(player, this);
    }

    private void FixedUpdate()
    {
        currentState.FixedState(player, this);
    }
}
