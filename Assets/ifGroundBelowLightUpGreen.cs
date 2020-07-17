using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifGroundBelowLightUpGreen : MonoBehaviour
{
    SpriteRenderer lightSprite;
    GameObject player;
    // Start is called before the first frame update


    void LightUpButton()
    {
        if (!player.GetComponent<CharController>().checkGrounded())
        {
            //bitshift the layer index
            int layerMask = 1 << 8;
            if (Physics.Raycast(transform.position, Vector3.down, 50f, layerMask))
            {
                lightSprite.color = Color.green;
            }
            else
            {
                lightSprite.color = Color.gray;
            }

        }




    }

    void Start()
    {
        lightSprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        LightUpButton();
    }

}