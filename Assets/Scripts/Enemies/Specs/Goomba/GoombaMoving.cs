using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMoving : MovingState
{
    private Goomba enemy;
    public GoombaMoving(EnemyStateFactory factory, EnemyStateMachine stateMachine, string animBoolName, MovingData stateData, Goomba _enemy) : base(factory, stateMachine, animBoolName, stateData)
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

        if(yesJump && isGrounded){
            stateMachine.ChangeState(enemy.jumpState);
        }
        else if(factory.isFollowing && factory.playerTooClose == 0){
            enemy.idleState.SetFlip(false);
            stateMachine.ChangeState(enemy.idleState);
        }
        else if(yesWall || yesGround == false){
            enemy.idleState.SetFlip(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
    }
}
