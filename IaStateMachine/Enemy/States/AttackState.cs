using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IAState
{
    protected Transform attackPosition;

    protected bool isAnimationFinished;
    protected bool isPlayerMinAgroRange;
    protected bool isPlayerMaxAgroRange;
    protected bool circleCheck;
    protected bool isInAtackPosition;

    public AttackState(Entity entity, IAStateMachine stateMachine, string animeBoolName, Transform attackPosition) : base(entity, stateMachine, animeBoolName)
    {
        this.attackPosition = attackPosition;
    }

    public override void Enter()
    {
        base.Enter();
        entity.atsm.AttackState = this;
        isAnimationFinished = false;
        entity.SetVelocity(0f);
        isPlayerMinAgroRange = entity.CheckPlayerMinAgroRange(); 
        isPlayerMaxAgroRange = entity.CheckPlayerMaxAgroRange();
        circleCheck = entity.CheckPlayerCircle();
        isInAtackPosition = entity.CheckIsInAtackPosition();
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

        isPlayerMinAgroRange = entity.CheckPlayerMinAgroRange(); 
        isPlayerMaxAgroRange = entity.CheckPlayerMaxAgroRange();
        circleCheck = entity.CheckPlayerCircle();
        isInAtackPosition = entity.CheckIsInAtackPosition();
    }

    public virtual void TriggerAttack()
    {

    }
    public virtual void FinishAttack()
    {
        isAnimationFinished = true;
    }
}
