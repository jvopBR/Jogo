using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newJumpStateData", menuName = "Data/State Data/Jump State")]
public class JumpData : ScriptableObject
{
    public float jumpingPower = 10f;
    public int velocitySets = 1;
}
