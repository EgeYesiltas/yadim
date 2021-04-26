using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChracterController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Animator anim;

    public bool isGrounded;
    public Transform feetpos;
    public float checRadius;
    public LayerMask whatIsGround;

    private float jumTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private static readonly int İsDie = Animator.StringToHash("isDie");

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        OnTriggerEnter2D("asd");
    }

    private void OnTriggerEnter2D(string dialogue)
    {
        throw new NotImplementedException();
    }

    void OnTriggerEnter2D(Collider2D dialogue)
    {
        if (dialogue.gameObject.tag.Equals("Ladder"))
        {
            moveInput = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (isGrounded == false )
        {
            Debug.Log("havada");
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
        isGrounded = Physics2D.OverlapCircle(feetpos.position, checRadius, whatIsGround);

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
    public void Die()
    {
        StartCoroutine(ChangeScene());
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Alive()
    {
        anim.SetBool("isDie", false);
    }
    private IEnumerator ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        throw new InvalidOperationException();
    }


}
