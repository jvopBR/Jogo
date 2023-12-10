using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_IdleState : IdleState
{
    Enemy3 enemy;

    public E3_IdleState(Entity entity, IAStateMachine stateMachine, string animeBoolName, D_IdleState stateData, Enemy3 enemy ) : base(entity, stateMachine,animeBoolName, stateData)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
