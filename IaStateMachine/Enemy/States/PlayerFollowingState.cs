using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowingState : IAState
{
    protected D_PlayerFollowing stateData;

    protected bool isPlayerMaxAgroRange;
    protected bool isPlayerMinAgroRange;
    protected bool isDetectingledge;
    protected bool isDetectingWall;
    protected bool isFollowingPlayer;
    protected bool performCloseRangeAction;
    protected bool playerCircle;

    public PlayerFollowingState(Entity entity, IAStateMachine stateMachine, string animeBoolName, D_PlayerFollowing stateData ) : base(entity, stateMachine,animeBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        isFollowingPlayer = false;
        isPlayerMinAgroRange = entity.CheckPlayerMinAgroRange();
        isPlayerMaxAgroRange = entity.CheckPlayerMaxAgroRange();
        isDetectingledge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        performCloseRangeAction = entity.CheckPlayerinCloseRangeAction();
        playerCircle = entity.CheckPlayerCircle();

        entity.SetVelocity(stateData.playerFollowingSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isPlayerMaxAgroRange)
        {
            isFollowingPlayer = true;
        }
        else
        {
            isFollowingPlayer = false;
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        isPlayerMinAgroRange = entity.CheckPlayerMinAgroRange();
        isPlayerMaxAgroRange = entity.CheckPlayerMaxAgroRange();
        isDetectingledge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        performCloseRangeAction = entity.CheckPlayerinCloseRangeAction();
        playerCircle = entity.CheckPlayerCircle();
    }
}
