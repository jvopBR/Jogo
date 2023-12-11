using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : EnemyBaseState
{
    protected JumpData stateData;

    public JumpState(EnemyStateFactory factory, EnemyStateMachine stateMachine, string animBoolName, JumpData _stateData) : base(factory, stateMachine, animBoolName)
    {
        stateData = _stateData;
    }
    protected bool isGrounded = true;
    protected float keepMoving;
    protected int velocitySet = 0;
    protected bool canExit = false;

    public override void EnterState(){
        base.EnterState();
        keepMoving = factory.rb.velocity.x;
        Debug.Log("Velocity x:" + keepMoving);

        factory.SetVelocity(0f, keepMoving, stateData.jumpingPower);
        velocitySet++;
    }

    public override void ExitState(){
        base.ExitState();
    }

    public override void LogicUpdate(){
        base.LogicUpdate();
        if(!isGrounded) canExit = true;
    }

    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
        if(velocitySet <= stateData.velocitySets){
            factory.SetVelocity(0f, keepMoving, stateData.jumpingPower);
            velocitySet++;
        }
        isGrounded = factory.IsGrounded();
    }
}