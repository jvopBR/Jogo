using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyBaseState
{
    protected IdleData stateData;

    protected bool flipInExit;
    protected bool waitIsOver;

    protected float IdleTime;

    public IdleState(EnemyStateFactory factory, EnemyStateMachine stateMachine, string animBoolName, IdleData _stateData) : base(factory, stateMachine, animBoolName)
    {
        stateData = _stateData;
    }

    public override void EnterState(){
        base.EnterState();

        factory.SetVelocity(0f);

        waitIsOver = false;
        IdleTime = SetIdleTime();
    }

    public override void ExitState(){
        base.ExitState();

        if(flipInExit){
            factory.Flip();
        }
    }

    public override void LogicUpdate(){
        base.LogicUpdate();

        if(Time.time >= startTime + IdleTime){
            waitIsOver = true;
        }
    }

    public override void PhysicsUpdate(){
        base.PhysicsUpdate();

    }
    
    public void SetFlip(bool flip){
        flipInExit = flip;
    }

    private float SetIdleTime(){
        return Random.Range(stateData.minWaitingTime, stateData.maxWaitingTime);
    }
}