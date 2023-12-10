using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Movement Movement { get; private set; }
    public CollisionSenses CollisionSenses { get; private set; }
    private Stats stats;

    public Stats Stats 
    {
        get => GenericNotImplementedError<Stats>.TryGet(stats, transform.parent.name);
        set => stats = value;
    }

    public void Awake()
    {
        Movement = GetComponentInChildren<Movement>();
        CollisionSenses = GetComponentInChildren<CollisionSenses>();
        Stats = GetComponentInChildren<Stats>();

        if (Movement == null || CollisionSenses == null)
        {
            Debug.LogError("Core: Movement or CollisionSenses not found in children");
        }
    }

    public void LogicUpdate()
    {
        Movement.LogicUpdate();
    }

}
