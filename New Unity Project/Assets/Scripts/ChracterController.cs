using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    public float distance;
    public LayerMask whatIsLadder;
    private bool isClimbing;
    private float inputVertical;
    private float inputHorizontal;
    public float climbingSpeed;

    private Rigidbody2D rb;

    private bool facingRight = true;


    private bool isGrounded;
    public Transform groundCheck;
    public float ceheckRadius;
    public LayerMask whatIsGround;


    private int extraJumps;
    public int extraJumpsValue;
    
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void x()
    {
        if (isClimbing = true)
        {
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * climbingSpeed);
            rb.gravityScale = 0;
            Debug.Log("x");
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, ceheckRadius, whatIsGround);

        

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

     
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        if (hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                isClimbing = true;
            }
        }else {
            isClimbing = false;
        }

        if (isClimbing == true)
        {
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * climbingSpeed);
            rb.gravityScale = 0;
           
        }else{
            rb.gravityScale = 1;
        }

        if (isClimbing == true)
        {
            Debug.Log("tırmanıyo");
        }else {
            Debug.Log("tırmanmıyor");
        }

        
    }

    void Update()
    {
        if (isGrounded == true)     
        {
            extraJumps = extraJumpsValue;
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
