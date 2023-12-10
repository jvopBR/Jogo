using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_PlayerDetectedState : PlayerDetected2State
{
    private Enemy2 enemy;

    public E2_PlayerDetectedState(Entity entity, IAStateMachine stateMachine, string animeBoolName, D_PlayerDetected2State stateData, Enemy2 enemy) : base(entity, stateMachine, animeBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(performCloseRangeAction)
        {
            stateMachine.ChangeState(enemy.meleeAtackState);
        }
        else if(performLongRangeAction)
        {
            stateMachine.ChangeState(enemy.PlayerFollowingState);
        }
        else if(!playerCircle)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }    
}
