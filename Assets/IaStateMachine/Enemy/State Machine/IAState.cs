using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAState
{
    protected IAStateMachine stateMachine;
    protected Entity entity;

    public float startTime {get; protected set; }

    protected string animeBoolName;

    public IAState( Entity entity, IAStateMachine stateMachine, string animeBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animeBoolName = animeBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animeBoolName, true);
   
    }

    public virtual void Exit()
    {
        entity.anim.SetBool(animeBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }
}


