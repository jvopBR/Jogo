using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MelleAttackState : MeleeAtackState
{
    private Enemy1 enemy;

    public E1_MelleAttackState(Entity entity, IAStateMachine stateMachine, string animeBoolName, Transform attackPosition , D_MeleeAtack stateData, Enemy1 enemy) : base(entity, stateMachine,animeBoolName, attackPosition, stateData)
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

        if(Time.time >= enemy.DodgeState.startTime + enemy.DodgeStateData.dodgeCoolDown)
        {
            stateMachine.ChangeState(enemy.DodgeState);
        }

        else if(isAnimationFinished)
        {
            if(isPlayerMinAgroRange)
            {
                stateMachine.ChangeState(enemy.playerDetected1State);
            }
            else if(!isPlayerMaxAgroRange)
            {
                stateMachine.ChangeState(enemy.LookForPlayerState);
            }
        }
        else if(!isPlayerMaxAgroRange)
        {
            stateMachine.ChangeState(enemy.LookForPlayerState);
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
