using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState :  IAState
{
    protected D_IdleState stateData;

    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;
    protected bool isPlayerMinAgroRange;
    protected bool playerCircle;

    protected float idleTime;

    public IdleState(Entity entity, IAStateMachine stateMachine, string animeBoolName, D_IdleState stateData): base(entity, stateMachine, animeBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(0f);
        isIdleTimeOver = false;
        isPlayerMinAgroRange = entity.CheckPlayerMinAgroRange();
        playerCircle = entity.CheckPlayerCircle();
        SetRandomIdleTime();
    }
    public override void Exit()
    {
        base.Exit();

        if(flipAfterIdle)
        {
            entity.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        isPlayerMinAgroRange = entity.CheckPlayerMinAgroRange();
        playerCircle = entity.CheckPlayerCircle();
    }

    public void SetFlipAfterIdle(bool flip)
    {
        flipAfterIdle = flip;
    }

    public void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}
