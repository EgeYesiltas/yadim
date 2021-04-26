using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yhtfrzs : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private float inputHorizontal;
    private float inputVertical;
    public float distance;
    public LayerMask WhatIsLadder;
    private bool isClimbing;

    void start()
    {print("x");
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        print("x");
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, WhatIsLadder);

        if (hitInfo.collider != null)
        {print("x");
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {print("x");
                isClimbing = true;
            }
        }
        else
        {print("x");
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
                isClimbing = false;
                print("x");
            }
        }
            

        if (isClimbing = true && hitInfo.collider)
        {print("x");
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
            rb.gravityScale = 0;
        }
        else
        {print("x");
            rb.gravityScale = 1;
        }
    }
}
