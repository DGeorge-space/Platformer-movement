using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    
    private bool facingRight = true;
    public float amountToAccelerate; //rewrite this as a function that is dependent on the existing velocity, 
    InputHandling handleInput;
    public float jumpHeight;
    public float maxAcceleration;

    Rigidbody rb;

    void changeDirection()
    {
        transform.Rotate(0,0,180f);
        facingRight = !facingRight;  //will be important for when parallaxing is introduced
    }



    public void velocitySolver(int lORr){
        Vector3 valToReturn = new Vector3(0,0,0);

        if (Mathf.Abs(GetComponent<Rigidbody>().velocity.x) >= maxAcceleration){
            rb.velocity += new Vector3(0,0,0);
        }
        else{
            rb.velocity += new Vector3(amountToAccelerate * Time.deltaTime * lORr, 0, 0);
        }      
    }

    void triggerChangeDirection(){
        if((facingRight && rb.velocity.x<0)||(!facingRight && rb.velocity.x>0)){
            changeDirection();
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
        
        rb.AddForce(transform.up*jumpHeight);
    }

    public void ifGroundedExecuteJump(){
        if(checkGrounded()){
            jump();
        }
    }
    public void dropDown(){
        rb.AddForce(-transform.up*jumpHeight/10);
    }


    // Start is called before the first frame update


    void Start()
    {
        handleInput= GameObject.Find("GameManager").GetComponent<InputHandling>();
        rb = GetComponent<Rigidbody>();

    }


}
