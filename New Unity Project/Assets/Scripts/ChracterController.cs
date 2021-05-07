using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool isClimbing;
    private float inputVertical;
    private float inputHorizontal;

    private Rigidbody2D rb;
    private Animator anim;

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
        anim = GetComponent<Animator>();
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

        
            
        if(isGrounded == false)
        {
            anim.SetBool("zıplıyo", true);
        }else {
            anim.SetBool("zıplıyo", false);
        }

        if (moveInput > 0 || moveInput < 0)
        {
            anim.SetBool("yürüyo", true);
        }else{
            anim.SetBool("yürüyo",false);
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


    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("pushable"))
        {
            anim.SetBool("itiriyor", true);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Merdiven"))
        {
            anim.SetBool("tırmanıyo", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("pushable"))
        {
            anim.SetBool("itiriyor", false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Merdiven"))
        {
            anim.SetBool("tırmanıyo", false);
        }
    }
    
    
}
