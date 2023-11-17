using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newFactoryData", menuName = "Data/Factory Data/Base Data")]
public class FactoryData : ScriptableObject
{
   public float wcDistace = 0.2f;
   public float gcDistance = 0.4f;
   
   public LayerMask isGround;

}
