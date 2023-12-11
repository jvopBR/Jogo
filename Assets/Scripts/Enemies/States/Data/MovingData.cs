using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMovingStateData", menuName = "Data/State Data/Moving State")]
public class MovingData : ScriptableObject
{
    public float speed = 3f;
    public float followingSpeed = 5f;
}
