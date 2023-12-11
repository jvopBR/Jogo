using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaIdle : IdleState
{
    public Goomba enemy;
    public GoombaIdle(EnemyStateFactory factory, EnemyStateMachine stateMachine, string animBoolName, IdleData stateData, Goomba _enemy) : base(factory, stateMachine, animBoolName, stateData)
    {
        enemy = _enemy;
    }

    public override void EnterState(){
        base.EnterState();
        Debug.Log("Enter Idle");
    }

    public override void ExitState(){
        base.ExitState();
    }

    public override void LogicUpdate(){
        base.LogicUpdate();

        if(waitIsOver){
            stateMachine.ChangeState(enemy.movingState);
        }
    }

    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
    }
}
