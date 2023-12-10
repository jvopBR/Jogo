using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDodgeStateData", menuName = "Data/State Data/Dodge State")]

public class D_DodgeStateData : ScriptableObject
{
    public float dodgeTime = 3f;
    public float dodgeSpeed = 10f;
    public float dodgeCoolDown = 20f;    
}

