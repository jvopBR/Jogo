using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Core core;

    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;

    protected bool isAnimationFinished;
    protected bool isExitingState;
    
    protected float startTime;

    private string animBoolName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
        core = player.Core;
    }

    public virtual void Enter() //Call when state is entered
    {
        startTime = Time.time;
        player.Anim.SetBool(animBoolName, true);
        DoChecks();
        //Debug.Log(animBoolName);
        isAnimationFinished = false;
        isExitingState = false;
    }

    public virtual void Exit() //Call when state is exited
    {
        player.Anim.SetBool(animBoolName, false);
        isExitingState = true;
    }

    public virtual void LogicUpdate() //Call in Update
    {
        
    }

    public virtual void PhysicsUpdate() //Call in FixedUpdate
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {
           
    }

    public virtual void AnimationTrigger() //Call in Animation Event
    {
        
    }
    public virtual void AnimationFinishTrigger() //Call in Animation Event
    {
        isAnimationFinished = true;
    }
}
