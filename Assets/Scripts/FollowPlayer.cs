using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void followPlayer(){
        playerPos = GameObject.Find("Player").transform.position;
        transform.position = new Vector3(playerPos.x,playerPos.y,transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        followPlayer();
        
    }
}
