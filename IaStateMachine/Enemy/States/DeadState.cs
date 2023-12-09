using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IAState
{
    protected D_DeadState stateData;

    public DeadState(Entity entity, IAStateMachine stateMachine, string animeBoolName, D_DeadState stateData) : base(entity, stateMachine,animeBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        GameObject.Instantiate(stateData.deathBloodParticle, entity.transform.position, stateData.deathBloodParticle.transform.rotation);
        GameObject.Instantiate(stateData.deathParticle, entity.transform.position, stateData.deathParticle.transform.rotation);

        entity .gameObject.SetActive(false);
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
    }
}
