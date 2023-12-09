using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : IAState
{
    protected D_DodgeStateData stateData;

    protected bool isDetectingledge;
    protected bool isDetectingWall;
    protected bool isPlayerMaxAgroRange;
    protected bool isPlayerMinAgroRange; 
    protected bool performCloseRangeAction;

    protected bool isDodgeOver;

    public DodgeState(Entity entity, IAStateMachine stateMachine, string animeBoolName, D_DodgeStateData stateData) : base(entity, stateMachine,animeBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        isDodgeOver = false;

        isDetectingledge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        isPlayerMaxAgroRange = entity.CheckPlayerMaxAgroRange();
        isPlayerMinAgroRange = entity.CheckPlayerMinAgroRange();

        entity.SetVelocity(-stateData.dodgeSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= stateData.dodgeTime + startTime)
        {
            isDodgeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        isDetectingledge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        isPlayerMaxAgroRange = entity.CheckPlayerMaxAgroRange();
        isPlayerMinAgroRange = entity.CheckPlayerMinAgroRange();
    }
}