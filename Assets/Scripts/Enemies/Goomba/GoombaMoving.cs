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
        Debug.Log("Enter Moving");
    }

    public override void ExitState(){
        base.ExitState();
    }

    public override void LogicUpdate(){
        base.LogicUpdate();

        if(yesWall || !yesGround){
            enemy.idleState.SetFlip(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
    }
}
