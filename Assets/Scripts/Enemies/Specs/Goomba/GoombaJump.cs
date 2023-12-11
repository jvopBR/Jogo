using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaJump : JumpState
{
    protected Goomba enemy;

    public GoombaJump(EnemyStateFactory factory, EnemyStateMachine stateMachine, string animBoolName, JumpData stateData, Goomba _enemy) : base(factory, stateMachine, animBoolName, stateData)
    {
        enemy = _enemy;
    }

    public override void EnterState(){
        base.EnterState();
    }

    public override void ExitState(){
        base.ExitState();
    }

    public override void LogicUpdate(){
        base.LogicUpdate();
        if(isGrounded && canExit){
            stateMachine.ChangeState(enemy.movingState);
        }
    }

    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
    }
}
