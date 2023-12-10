using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_LookForPlayerState : LookForPlayerState
{
    private Enemy1 enemy;

    public E1_LookForPlayerState(Entity entity, IAStateMachine stateMachine, string animeBoolName, D_LookForPlayerState stateData, Enemy1 enemy ) : base(entity, stateMachine,animeBoolName, stateData)
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

        if(isPlayerMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetected1State);
        }
        else if(isAllTurnsTimeDone)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
