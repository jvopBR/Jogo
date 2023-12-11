using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState
{
    protected EnemyStateMachine stateMachine;
    protected EnemyStateFactory factory;

    protected float startTime;

    protected string animBoolName;

    public EnemyBaseState(EnemyStateFactory _factory, EnemyStateMachine _stateMachine, string _animBoolName){
        factory = _factory;
        stateMachine = _stateMachine;
        animBoolName = _animBoolName;
    }

    public virtual void EnterState(){
        startTime = Time.time;
        factory.anim.SetBool(animBoolName, true);
    }

    public virtual void ExitState(){
        factory.anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate(){}

    public virtual void PhysicsUpdate(){}


}
