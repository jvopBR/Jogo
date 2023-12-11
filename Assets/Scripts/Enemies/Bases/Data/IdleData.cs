using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newIdleStateData", menuName = "Data/State Data/Idle State")]
public class IdleData : ScriptableObject
{
    public float minWaitingTime = 1f;
    public float maxWaitingTime = 4f;
}
