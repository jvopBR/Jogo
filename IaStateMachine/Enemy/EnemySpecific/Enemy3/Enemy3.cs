using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Entity
{
    public E3_IdleState idleState {get; private set; }
    public E3_MoveState moveState {get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;

    public override void Start()
    {
        base.Start();

        moveState = new E3_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E3_IdleState(this, stateMachine, "idle", idleStateData, this);
    
        stateMachine.Initilize(moveState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        //Gizmos.DrawWireSphere(meleeAtackPosition.position, meleeAtackStateData.attackRadius);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        //if(isDead)
        //{
            //stateMachine.ChangeState(DeadState);
        //}
    }
}
