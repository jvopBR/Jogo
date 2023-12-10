using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayerState : IAState
{
    protected D_LookForPlayerState stateData;

    protected bool isFollowingPlayer;
    protected bool turnImidiately;
    protected bool isPlayerMinAgroRange;
    protected bool isAllTurnsDone;
    protected bool isAllTurnsTimeDone;
    protected bool isInAtackPosition;
    protected bool circleCheck;

    protected float lastTurnTime;

    protected int amountOfTurnsDone;

    public LookForPlayerState(Entity entity, IAStateMachine stateMachine, string animeBoolName, D_LookForPlayerState stateData) : base(entity, stateMachine, animeBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        isAllTurnsDone = false;
        isAllTurnsTimeDone = false;

        lastTurnTime = startTime;
        entity.SetVelocity(0f);

        isPlayerMinAgroRange = entity.CheckPlayerMinAgroRange();
        isInAtackPosition = entity.CheckIsInAtackPosition();
        circleCheck = entity.CheckPlayerCircle();
    }
    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
{
    base.LogicUpdate();

    if (stateData != null && entity != null)
    {
        if (turnImidiately)
        {
            entity.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
            turnImidiately = false;
        }
        else if (Time.time >= lastTurnTime + stateData.timeBetweenTurns && !isAllTurnsDone)
        {
            entity.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
        }

        if (amountOfTurnsDone >= stateData.amountOfTurns)
        {
            isAllTurnsDone = true;
        }

        if (Time.time >= lastTurnTime + stateData.timeBetweenTurns && isAllTurnsDone)
        {
            isAllTurnsTimeDone = true;
        }
    }
}

public override void PhysicsUpdate()
{
    base.PhysicsUpdate();

    if (entity != null)
    {
        isPlayerMinAgroRange = entity.CheckPlayerMinAgroRange();
        isInAtackPosition = entity.CheckIsInAtackPosition();
        circleCheck = entity.CheckPlayerCircle();
    }
}


    public void SetTurnImmeadiately(bool flip)
    {
        turnImidiately = flip;
    }
}
