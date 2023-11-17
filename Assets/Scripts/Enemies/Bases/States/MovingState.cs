using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : EnemyBaseState
{
    protected MovingData stateData;

    protected bool yesWall;
    protected bool yesGround;

    public MovingState(EnemyStateFactory factory, EnemyStateMachine stateMachine, string animBoolName, MovingData _stateData) : base(factory, stateMachine, animBoolName)
    {
        stateData = _stateData;
    }

    public override void EnterState(){
        base.EnterState();
        factory.SetVelocity(stateData.speed);

        yesGround = factory.CheckGround();
        Debug.Log(yesGround);
        yesWall = factory.CheckWall();
        Debug.Log(yesWall);
    }

    public override void ExitState(){
        base.ExitState();

    }

    public override void LogicUpdate(){
        base.LogicUpdate();

    }

    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
        factory.SetVelocity(stateData.speed);

        yesGround = factory.CheckGround();
        Debug.Log(yesGround);
        yesWall = factory.CheckWall();
        Debug.Log(yesWall);
    }
}
