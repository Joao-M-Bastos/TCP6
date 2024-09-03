using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyBaseState
{
    public void EnterState();

    public void ExitState();

    public void UpdateState();

    public void FixedState();
}
