using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    
    public bool facingRight = true;
    public float amountToAccelerate; //rewrite this as a function that is dependent on the existing velocity, 
    InputHandling handleInput;
    public float jumpHeight;
    public float maxAcceleration;
    public float startTimeJumpDown;
    public float endTimeJumpDown;
    ParticleSystem particles;

    public float timeElapsedHoldingJump;
    Rigidbody rb;

    public void velocitySolver(int lORr){
        Vector3 valToReturn = new Vector3(0,0,0);

        if (Mathf.Abs(GetComponent<Rigidbody>().velocity.x) >= maxAcceleration){
            rb.velocity += new Vector3(0,0,0);
            
        }
        else{
            rb.velocity += new Vector3(amountToAccelerate * Time.deltaTime * lORr, 0, 0);
        }   
        
    }



    public bool checkGrounded()
    {
        float DisstanceToTheGround = GetComponent<Collider>().bounds.extents.y;
        float extentX = GetComponent<Collider>().bounds.extents.x/2;

        //stops object getting stranded if only partially on an object
        Vector3 xPosL = new Vector3(transform.position.x - extentX, transform.position.y, transform.position.z);
        Vector3 xPosR = new Vector3(transform.position.x + extentX, transform.position.y, transform.position.z);

        bool IsGroundedL = Physics.Raycast(xPosL, Vector3.down, DisstanceToTheGround + 0.1f);
        bool IsGroundedR = Physics.Raycast(xPosR, Vector3.down, DisstanceToTheGround + 0.1f);

        if (IsGroundedL || IsGroundedR)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public void jump(){

        if(timeElapsedHoldingJump>.5f){
            timeElapsedHoldingJump = 1.2f;
        }
        else if(timeElapsedHoldingJump<0.3f){
            
            timeElapsedHoldingJump = 0.5f;
        }
        particles.Play();
        rb.AddForce(transform.up*jumpHeight*timeElapsedHoldingJump);


    }

    public void ifGroundedExecuteJump(){
        if(checkGrounded()){
            jump();
        }
    }
    public void dropDown(){
        rb.AddForce(-transform.up*jumpHeight/10);
    }


    void switchDirection(){
        if(facingRight){
            GetComponent<SpriteRenderer>().flipX=false;
            
        }
        if(!facingRight){
            GetComponent<SpriteRenderer>().flipX=true;
        }
         //will be important for when parallaxing is introduced
    }

    void Start()
    {

        
        handleInput= GameObject.Find("GameManager").GetComponent<InputHandling>();
        rb = GetComponent<Rigidbody>();
        particles = GetComponentInChildren<ParticleSystem>();
        

    }
    void Update(){
        
        switchDirection();
        if(Input.GetKeyDown(KeyCode.Space)){
            startTimeJumpDown=Time.time;
            
        }
        
        if(Input.GetKeyUp(KeyCode.Space)){
            endTimeJumpDown=Time.time;
            timeElapsedHoldingJump= endTimeJumpDown-startTimeJumpDown;
            ifGroundedExecuteJump();
            
        }
        
    }


}
