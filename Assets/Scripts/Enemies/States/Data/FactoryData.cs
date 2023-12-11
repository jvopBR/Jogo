using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newFactoryData", menuName = "Data/Factory Data/Base Data")]
public class FactoryData : ScriptableObject
{
   public float wcDistace = 0.2f;
   public float gcDistance = 0.4f;
   public float pcHeight = 2f;

   public float close = 4f;
   public float safe = 3f;
   public float tooClose = 2f;
   
   public LayerMask isGround;
}
