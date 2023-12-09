using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Entity
{
    public E2_MoveState moveState {get; private set; }
    public E2_IdleState idleState {get; private set; }
    public E2_PlayerDetectedState playerDetected2State {get; private set; }
    public E2_MeleeAttackState meleeAtackState {get; private set; }
    public E2_LookForPlayerState lookForPlayerState {get; private set; }
    public E2_FollowingState PlayerFollowingState {get; private set; }
    public E2_DeadState DeadState {get; private set; }

    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_PlayerDetected2State playerDetected2Data;
    [SerializeField]
    private D_MeleeAtack meleeAtackStateData;
    [SerializeField]
    private D_LookForPlayerState lookForPlayerStateData;
    [SerializeField]
    private D_PlayerFollowing playerfollowingData;
    [SerializeField]
    private D_DeadState DeadStateData;

    [SerializeField]
    private Transform meleeAtackPosition;

    public override void Start()
    {
        base.Start();

        moveState = new E2_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E2_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetected2State = new E2_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetected2Data, this);
        meleeAtackState = new E2_MeleeAttackState(this, stateMachine, "meleeAtack", meleeAtackPosition, meleeAtackStateData, this);
        lookForPlayerState = new E2_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        PlayerFollowingState = new E2_FollowingState(this, stateMachine, "followingState", playerfollowingData, this);
        DeadState = new E2_DeadState(this, stateMachine, "deadState", DeadStateData, this);

        stateMachine.Initilize(moveState);
    }

     public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if(isDead)
        {
            stateMachine.ChangeState(DeadState);
        }
    }
    
}
