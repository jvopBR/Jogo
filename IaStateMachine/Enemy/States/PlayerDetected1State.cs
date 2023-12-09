using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetected1State : IAState
{
    protected D_PlayerDetected1 stateData;

    protected bool isPlayerMinAgroRange;
    protected bool isPlayerMaxAgroRange;
    protected bool performLongRangeAction;
    protected bool performCloseRangeAction;
    protected bool playerCircle;

    public PlayerDetected1State(Entity entity, IAStateMachine stateMachine, string animeBoolName, D_PlayerDetected1 stateData) : base(entity, stateMachine, animeBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(0f);
        performLongRangeAction = false;
        isPlayerMinAgroRange = entity.CheckPlayerMinAgroRange();
        isPlayerMaxAgroRange = entity.CheckPlayerMaxAgroRange();
        performCloseRangeAction = entity.CheckPlayerinCloseRangeAction();  
        playerCircle = entity.CheckPlayerCircle();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + stateData.LongRangeActionTime)
        {
            performLongRangeAction = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        isPlayerMinAgroRange = entity.CheckPlayerMinAgroRange();
        isPlayerMaxAgroRange = entity.CheckPlayerMaxAgroRange();
        performCloseRangeAction = entity.CheckPlayerinCloseRangeAction();    
        playerCircle = entity.CheckPlayerCircle();
    }
}

