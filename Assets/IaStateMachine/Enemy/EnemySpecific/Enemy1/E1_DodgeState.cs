using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_DodgeState : DodgeState
{
    Enemy1 enemy;

    public E1_DodgeState(Entity entity, IAStateMachine stateMachine, string animeBoolName, D_DodgeStateData stateData, Enemy1 enemy ) : base(entity, stateMachine,animeBoolName, stateData)
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isDodgeOver)
        {
            if(!isPlayerMaxAgroRange)
            {
                stateMachine.ChangeState(enemy.LookForPlayerState);
            }
            else if(isPlayerMaxAgroRange && performCloseRangeAction)
            {
                stateMachine.ChangeState(enemy.meleeAtackState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
