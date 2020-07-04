using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandling : MonoBehaviour
{
    
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
            return "Left";
        }
        else if (Input.GetKey(KeyCode.D))
        {
            return "Right";
        }
        else if (Input.GetKey(KeyCode.Space)){
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        identifyInput();


    }
}
