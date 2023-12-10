using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_FollowingState : PlayerFollowingState
{
    private Enemy2 enemy;

    public E2_FollowingState(Entity entity, IAStateMachine stateMachine, string animeBoolName, D_PlayerFollowing stateData, Enemy2 enemy ) : base(entity, stateMachine,animeBoolName, stateData)
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

        else if(!isDetectingledge || isDetectingWall)
        {
            entity.SetVelocity(0f);
            stateMachine.ChangeState(enemy.lookForPlayerState);
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
