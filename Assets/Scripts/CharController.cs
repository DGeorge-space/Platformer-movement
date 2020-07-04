using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    
    private bool facingRight = true;
    public float amountToAccelerate;

    void changeDirection()
    {
        transform.Rotate(0,0,180f);
        facingRight = !facingRight;
    }

    int leftOrRght()
    {
        InputHandling handleInput= GameObject.Find("GameManager").GetComponent<InputHandling>();
        string LorR = handleInput.processInput();
        if (LorR == "Right")
        {
            return 1;
        }
        else if (LorR == "Left")
        {
            return -1;
        }
        else
        {
            return 0;
        };
    }

    void addVelo()
    {

        GetComponent<Rigidbody>().velocity += new Vector3(amountToAccelerate * Time.deltaTime * leftOrRght(), 0, 0);
    }

    void triggerChangeDirection(){
        if((facingRight && GetComponent<Rigidbody>().velocity.x<0)||(!facingRight && GetComponent<Rigidbody>().velocity.x>0)){
            changeDirection();
        }
    }



    // Start is called before the first frame update


    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        addVelo();
        triggerChangeDirection();
        Debug.Log(GetComponent<Rigidbody>().velocity.x);
    }
}
