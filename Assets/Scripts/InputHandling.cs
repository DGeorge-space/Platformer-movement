﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandling : MonoBehaviour
{
    CharController character;
    
    public void identifyInput()
    {
        if (Input.anyKeyDown)
        {

            processInput();

        }


    }

    public string processInput()
    {


        if (Input.GetKey(KeyCode.A))
        {
            character.addVelo(-1);
            return "Left";
        }
        else if (Input.GetKey(KeyCode.D))
        {
            character.addVelo(1);
            return "Right";
        }
        else if (Input.GetKey(KeyCode.Space)){

            character.ifGroundedExecuteJump();
            
            return "Jump";
        }
        else if (Input.GetKey(KeyCode.P)){
            return "Pause";
        }
        else if (Input.GetKey(KeyCode.KeypadEnter)){
            return "Enter";
        }
        else{
            return "Not Acknowledged Input";
        }
        
    }

    /*At this point processInput is preventing the player from moving and jumping at the same time, a remedy for this is thought to be creating an input handler that listens for specific input and that separates the jump and add velo functions. 

    Similarly, work needs to be done to improve the velocity while in the air */

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindWithTag("Player").GetComponent<CharController>();

    }

    // Update is called once per frame
    void Update()
    {
        identifyInput();


    }
}
