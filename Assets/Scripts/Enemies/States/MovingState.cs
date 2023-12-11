using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : EnemyBaseState
{
    protected MovingData stateData;

    protected bool yesWall;
    protected bool yesGround;
    protected bool yesJump;
    protected bool isGrounded;
    protected float playerFar;

    public MovingState(EnemyStateFactory factory, EnemyStateMachine stateMachine, string animBoolName, MovingData _stateData) : base(factory, stateMachine, animBoolName)
    {
        stateData = _stateData;
    }

    public override void EnterState(){
        base.EnterState();
        if(!factory.isFollowing) factory.SetVelocity(stateData.speed, 0f, 0f);
        else factory.SetVelocity(stateData.followingSpeed * factory.playerTooClose, 0f, 0f);

        yesGround = factory.CheckGround();
        Debug.Log("There is ground: " + yesGround);
        yesWall = factory.CheckWall();
        Debug.Log("There is wall: " + yesWall);
        yesJump = factory.CheckPlatafomrs();
        Debug.Log("There is a plataform: " + yesJump);
        isGrounded = factory.IsGrounded();

        playerFar = factory.DistancePlayer();
        Debug.Log("Player " + playerFar + " meters far");
    }

    public override void ExitState(){
        base.ExitState();
    }

    public override void LogicUpdate(){
        base.LogicUpdate();
    }

    public override void PhysicsUpdate(){
        base.PhysicsUpdate();
        if(!factory.isFollowing) factory.SetVelocity(stateData.speed, 0f, 0f);
        else factory.SetVelocity(stateData.followingSpeed * factory.playerTooClose, 0f, 0f);
        yesGround = factory.CheckGround();
        Debug.Log("There is ground: " + yesGround);
        yesWall = factory.CheckWall();
        Debug.Log("There is wall: " + yesWall);
        yesJump = factory.CheckPlatafomrs();
        Debug.Log("There is a plataform: " + yesJump);
        isGrounded = factory.IsGrounded();

        playerFar = factory.DistancePlayer();
        Debug.Log("Player " + playerFar + " meters far");
    }
}
