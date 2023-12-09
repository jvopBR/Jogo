using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAtackState : AttackState
{
    protected D_MeleeAtack stateData;

    protected AttackDetails attackDetails;


    public MeleeAtackState(Entity entity, IAStateMachine stateMachine, string animeBoolName, Transform attackPosition, D_MeleeAtack stateData) : base(entity, stateMachine,animeBoolName, attackPosition)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();        

        attackDetails.damageAmount = stateData.attackDamage;
        attackDetails.position = entity.aliveGO.transform.position;
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        Collider2D[] detecteObjects  = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);
        foreach (Collider2D collider in detecteObjects)
        {
            //collider.transform.SendMenssage("Damage", attackDetails);
        }
    }
}
