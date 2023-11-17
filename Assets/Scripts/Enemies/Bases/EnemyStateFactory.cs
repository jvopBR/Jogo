using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateFactory : MonoBehaviour
{
    //State Machine Scripsts
    public EnemyStateMachine stateMachine;
    public FactoryData factoryData;
    
    
    public int isFacingRight { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject aliveGo { get; private set; }

    [SerializeField] private Transform groundCheck;

    private Vector2 velocityV;

    public virtual void Start (){
        //Game Object with animations
        aliveGo = transform.Find("alive").gameObject;
        rb = aliveGo.GetComponent<Rigidbody2D>();
        anim = aliveGo.GetComponent<Animator>();
        
        //Set state machine
        stateMachine = new EnemyStateMachine();
        //Set position
        isFacingRight = 1;
    }

    #region updates
    public virtual void Update (){
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate (){
        stateMachine.currentState.PhysicsUpdate();
    }
    #endregion


    #region methods
    //Define moving
    public virtual void SetVelocity(float velocity){
        velocityV.Set(isFacingRight * velocity, rb.velocity.y);
        rb.velocity = velocityV;
        
        Debug.Log("Velocity setted");
        Debug.Log("Speed: " + velocity + " and velocity.x: " + isFacingRight*velocity);
    }

    //Sees Walls
    public virtual bool CheckWall(){
        return Physics2D.Raycast(groundCheck.position + new Vector3(0f, 0.5f, 0f), aliveGo.transform.right * isFacingRight, factoryData.wcDistace, factoryData.isGround);
    }

    //Sees plataforms
    public virtual bool CheckGround(){
        return Physics2D.Raycast(groundCheck.position + new Vector3(1f * isFacingRight, 0f, 0f), Vector2.down, factoryData.gcDistance, factoryData.isGround);
    }

    //Flip the character
    public virtual void Flip(){
        isFacingRight *= -1;
        aliveGo.transform.Rotate(0f, 180f, 0f);
    }
    #endregion
}
