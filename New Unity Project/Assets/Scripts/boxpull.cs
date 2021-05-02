using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boxpull : MonoBehaviour
{
    public bool beingPushed;
    float xPos;
    private Animator anim;

    private void Start()
    {
        anim = new Animator();
        xPos = transform.position.x;
    }

    private void Update()
    {
        if (beingPushed == false)
        {
            transform.position = new Vector3(xPos, transform.position.y);
            
        }
        else
        {
            xPos = transform.position.x;
        }
        
    }
}
