using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    
    private bool facingRight = true;
    public float amountToAccelerate; //rewrite this as a function that is dependent on the existing velocity, 
    InputHandling handleInput;
    public float jumpHeight;

    void changeDirection()
    {
        transform.Rotate(0,0,180f);
        facingRight = !facingRight;  //will be important for when parallaxing is introduced
    }



    public void addVelo(int lORr)
    {

        GetComponent<Rigidbody>().velocity += new Vector3(amountToAccelerate * Time.deltaTime * lORr, 0, 0);
    }

    void triggerChangeDirection(){
        if((facingRight && GetComponent<Rigidbody>().velocity.x<0)||(!facingRight && GetComponent<Rigidbody>().velocity.x>0)){
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
        
        GetComponent<Rigidbody>().velocity+= new Vector3(0,jumpHeight*Time.deltaTime,0);
        
    }

    public void ifGroundedExecuteJump(){
        if(checkGrounded()){
            jump();
        }
    }


    // Start is called before the first frame update


    void Start()
    {
        handleInput= GameObject.Find("GameManager").GetComponent<InputHandling>();

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(checkGrounded());
 
    }
}
