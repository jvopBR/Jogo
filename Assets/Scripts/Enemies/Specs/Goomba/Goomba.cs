using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : EnemyStateFactory
{
    public GoombaIdle idleState { get; private set; }
    public GoombaMoving movingState { get; private set; }
    public GoombaJump jumpState { get; private set; }

    [SerializeField] private IdleData idleData;
    [SerializeField] private MovingData movingData;
    [SerializeField] private JumpData jumpData;

    public override void Start(){
        base.Start();

        movingState = new GoombaMoving(this, stateMachine, "moving", movingData, this);
        idleState = new GoombaIdle(this, stateMachine, "idle", idleData, this);
        jumpState = new GoombaJump(this, stateMachine, "jump", jumpData, this);

        stateMachine.Initialize(movingState);
    }
}
