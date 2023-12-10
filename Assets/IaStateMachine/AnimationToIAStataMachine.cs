using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToIAStataMachine : MonoBehaviour
{
    public AttackState AttackState;

    private void TriggerAttack()
    {
        AttackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        AttackState.FinishAttack();
    }
}
