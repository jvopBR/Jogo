using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_PlayerDetected1State : PlayerDetected1State
{
    private Enemy1 enemy;

    public E1_PlayerDetected1State(Entity entity, IAStateMachine stateMachine, string animeBoolName, D_PlayerDetected1 stateData, Enemy1 enemy) : base(entity, stateMachine, animeBoolName, stateData)
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
            if(Time.time >= enemy.DodgeState.startTime + enemy.DodgeStateData.dodgeCoolDown)
            {
                stateMachine.ChangeState(enemy.DodgeState);
            }
            else 
            {
                stateMachine.ChangeState(enemy.meleeAtackState);
            }
        }

        else if (performLongRangeAction)
        {
            stateMachine.ChangeState(enemy.PlayerFollowingState);
        }
        else if(!isPlayerMaxAgroRange)
        {
            stateMachine.ChangeState(enemy.LookForPlayerState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
