using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_LookForPlayerState : LookForPlayerState
{
    private Enemy2 enemy;

    public E2_LookForPlayerState(Entity entity, IAStateMachine stateMachine, string animeBoolName, D_LookForPlayerState stateData, Enemy2 enemy ) : base(entity, stateMachine,animeBoolName, stateData)
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

        if(circleCheck)
        {
            stateMachine.ChangeState(enemy.playerDetected2State);
        }
    
        else
        {
            stateMachine.ChangeState(enemy.moveState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
