using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_MeleeAttackState : MeleeAtackState
{
    private Enemy2 enemy;

    public E2_MeleeAttackState(Entity entity, IAStateMachine stateMachine, string animeBoolName, Transform attackPosition , D_MeleeAtack stateData, Enemy2 enemy) : base(entity, stateMachine,animeBoolName, attackPosition, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    
        if(isAnimationFinished)
        {
            if(!isInAtackPosition)
            {
                stateMachine.ChangeState(enemy.playerDetected2State);
            }
            else if(!circleCheck)
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
        else if(!circleCheck)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }    
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
