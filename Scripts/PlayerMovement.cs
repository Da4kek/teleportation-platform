using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed = 2f;
    public float JumpForce;
    private float moveInput;
    private bool facingRight = true;

    public Animator animator;

     
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WhatisGround;

    private int extraJumps;
    public int extraJumpsValue;

    void Start()
    {
        extraJumps = extraJumpsValue;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    




    void FixedUpdate()
    {


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatisGround);



        moveInput = Input.GetAxisRaw("Horizontal") * speed;

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

       
        if(facingRight == false && moveInput >0  )
        {
            Flip();
        }

        else if(facingRight ==true && moveInput <0)
        {
            Flip();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector2 Force  = new Vector2(0f , -35f);
            rb.AddForce(Force);
        }

        
        


    }

  



    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void Update()
    {

        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }


        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if(extraJumps >0)
            {
                rb.velocity = Vector2.up * JumpForce;
                extraJumps--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if(extraJumps == 0 && isGrounded == true)
            {
                rb.velocity = Vector2.up * JumpForce;
            }

            
        }
    }
    



}