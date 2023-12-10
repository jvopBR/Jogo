using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IAState
{
    protected D_MoveState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingledge;
    protected bool isPlayerMinAgroRange;
    protected bool playerCircle;

    public MoveState(Entity entity, IAStateMachine stateMachine, string animeBoolName, D_MoveState stateData) : base(entity, stateMachine,animeBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        isDetectingledge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        isPlayerMinAgroRange = entity.CheckPlayerMinAgroRange();
        playerCircle = entity.CheckPlayerCircle();

        entity.SetVelocity(stateData.movementSpeed);
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        isDetectingledge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        isPlayerMinAgroRange = entity.CheckPlayerMinAgroRange();
        playerCircle = entity.CheckPlayerCircle();
    }
}

