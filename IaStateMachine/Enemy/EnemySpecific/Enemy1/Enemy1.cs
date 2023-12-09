using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idleState {get; private set; }
    public E1_MoveState moveState {get; private set; }
    public E1_PlayerDetected1State playerDetected1State {get; private set; }
    public E1_PlayerFollowingState PlayerFollowingState {get; private set; }
    public E1_LookForPlayerState LookForPlayerState {get; private set; }
    public E1_MelleAttackState meleeAtackState {get; private set; }
    public E1_DeadState DeadState {get; private set; }
    public E1_DodgeState DodgeState {get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetected1 playerDetected1Data;
    [SerializeField]
    private D_PlayerFollowing playerfollowingData;
    [SerializeField]
    private D_LookForPlayerState lookForPlayerStateData;
    [SerializeField]
    private D_MeleeAtack meleeAtackStateData;
    [SerializeField]
    private D_DeadState DeadStateData;
    [SerializeField]
    public D_DodgeStateData DodgeStateData;

    [SerializeField]
    private Transform meleeAtackPosition;

    public override void Start()
    {
        base.Start();

        moveState = new E1_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E1_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetected1State = new E1_PlayerDetected1State(this, stateMachine, "playerDetected1", playerDetected1Data, this);
        PlayerFollowingState = new E1_PlayerFollowingState(this, stateMachine, "playerfollowing", playerfollowingData, this);
        LookForPlayerState = new E1_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        meleeAtackState = new E1_MelleAttackState(this, stateMachine, "meleeAtack", meleeAtackPosition, meleeAtackStateData, this);
        DeadState = new E1_DeadState(this, stateMachine, "dead", DeadStateData, this);
        DodgeState = new E1_DodgeState(this, stateMachine, "dodge", DodgeStateData, this);

        stateMachine.Initilize(moveState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAtackPosition.position, meleeAtackStateData.attackRadius);
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
