using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_PlayerFollowingState : PlayerFollowingState
{
    private Enemy1 enemy;

    public E1_PlayerFollowingState(Entity entity, IAStateMachine stateMachine, string animeBoolName, D_PlayerFollowing stateData, Enemy1 enemy ) : base(entity, stateMachine,animeBoolName, stateData)
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
            stateMachine.ChangeState(enemy.LookForPlayerState);
        }
        else if(!isFollowingPlayer)
        {
            if(isPlayerMinAgroRange)
            {
                stateMachine.ChangeState(enemy.playerDetected1State);
            }
            stateMachine.ChangeState(enemy.LookForPlayerState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

