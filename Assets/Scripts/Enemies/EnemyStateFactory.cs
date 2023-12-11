using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateFactory : MonoBehaviour
{
    //State Machine Scripsts
    public EnemyStateMachine stateMachine;
    public FactoryData factoryData;
    
    public bool isFollowing { get; private set; }
    public int playerTooClose { get; private set; }
    public int isFacingRight { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject aliveGo { get; private set; }
    public Transform player { get; private set; }

    [SerializeField] private Transform groundCheck;

    private Vector2 velocityV;
    private float distancePlayer;

    public virtual void Start (){
        //Game Object with animations
        aliveGo = transform.Find("alive").gameObject;
        if(aliveGo == null) Debug.Log("GameObject not found");
        else{
            rb = aliveGo.GetComponent<Rigidbody2D>();
            anim = aliveGo.GetComponent<Animator>();

            if(rb == null) Debug.Log("RigidBody not found");
            if(anim == null) Debug.Log("Animator not found");
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(player == null) Debug.Log("Player not found");

        //Set state machine
        stateMachine = new EnemyStateMachine();
        //Set position
        isFacingRight = 1;
        //
        distancePlayer = DistancePlayer();
        if( distancePlayer <= factoryData.tooClose ){
            isFollowing = true;
            playerTooClose = -1;
        }
        else if( distancePlayer <= factoryData.safe ){
            isFollowing = true;
            playerTooClose = 0;
        }
        else if( distancePlayer <= factoryData.close ){
            isFollowing = true;
            playerTooClose = 1;
        }
        else{
            isFollowing = false;
            playerTooClose = 0;
        }
    }

    #region updates
    public virtual void Update (){
        distancePlayer = DistancePlayer();
        if( distancePlayer <= factoryData.tooClose ){
            isFollowing = true;
            playerTooClose = -1;
        }
        else if( distancePlayer <= factoryData.safe ){
            isFollowing = true;
            playerTooClose = 0;
        }
        else if( distancePlayer <= factoryData.close ){
            isFollowing = true;
            playerTooClose = 1;
        }
        else{
            isFollowing = false;
            playerTooClose = 0;
        }
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate (){
        if(isFollowing){
            if((player.position.x < aliveGo.transform.position.x && isFacingRight == 1) || (player.position.x > aliveGo.transform.position.x && isFacingRight == -1)) Flip();
        }
        stateMachine.currentState.PhysicsUpdate();
    }
    #endregion


    #region methods
    //Define moving
    public virtual void SetVelocity(float velocity, float keep, float jump){
        velocityV.Set(isFacingRight * velocity + keep, jump);
        rb.velocity = velocityV;
        Debug.Log("Speed: " + velocity + " and velocity.x: " + (isFacingRight*velocity+keep) + "and velocity.y: " + jump);
    }

    //Sees Walls
    public virtual bool CheckWall(){
        Debug.DrawLine(groundCheck.position + new Vector3(0f, 0.5f, 0f), groundCheck.position + new Vector3(factoryData.wcDistace * isFacingRight, 0.5f, 0f), Color.green, 2.0f, false);
        return Physics2D.Raycast(groundCheck.position + new Vector3(0f, 0.5f, 0f), new Vector2(isFacingRight, 0f), factoryData.wcDistace, factoryData.isGround);   
    }

    //Sees plataforms
    public virtual bool CheckGround(){
        bool yes = Physics2D.Raycast(groundCheck.position + new Vector3(factoryData.gcDistance * isFacingRight, 0f, 0f), Vector2.down, factoryData.pcHeight, factoryData.isGround);
        bool no = Physics2D.Raycast(groundCheck.position + new Vector3(factoryData.gcDistance * 2 * isFacingRight, 0f, 0f), Vector2.down, factoryData.pcHeight, factoryData.isGround);
        if(yes || no) return true;
        return false;
    }

    public virtual bool CheckPlatafomrs(){
        return Physics2D.Raycast(groundCheck.position + new Vector3(2f * isFacingRight, factoryData.pcHeight, 0f), Vector2.down, factoryData.pcHeight, factoryData.isGround);
    }
    
    //Verify if it is on the floor
    public virtual bool IsGrounded(){
        bool yes = true;
        Collider2D existsGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, factoryData.isGround);
        if(existsGround == null) yes = false;
        Debug.Log("Is grounded: " + yes);
        return yes;
    }

    //Flip the character
    public virtual void Flip(){
        isFacingRight *= -1;
        aliveGo.transform.Rotate(0f, 180f, 0f);
    }

    //Distance to player
    public virtual float DistancePlayer(){
        return Vector2.Distance(aliveGo.transform.position, player.position);
    }
    #endregion
}