using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveState : MoveState
{
    private Enemy1 enemy;

    public E1_MoveState(Entity entity, IAStateMachine stateMachine, string animeBoolName, D_MoveState stateData, Enemy1 enemy) : base(entity, stateMachine,animeBoolName, stateData)
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
        if (isPlayerMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetected1State);
        }

        else if(isDetectingWall || !isDetectingledge)
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
