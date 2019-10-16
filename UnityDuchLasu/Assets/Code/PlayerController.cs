using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Player player;
    public Animator animator;

    public SpriteRenderer spriteRen;
    public float movmentForce = 0;
    public int speed = 0;
    public float maxSpeed = 0f;
    public float jumpDuration = 0f;
    
    public float jumpLowToMax = 0f;
    public bool canJump = false;
    public float wallFriction=0f;
    

    public bool wallSideL = true;
    public bool wallSideR = true;
    float wallGravity = 0f;
    Vector2 axisX = new Vector2(1f, 0f);
    Vector2 axisY = new Vector2(0f, 1f);


    float moveInput;
    public float velocity;
    bool faceingRight = true;
    public Transform feetPos;
    bool isGrounded;
    public float circleRadius;
    public float jumpForce;
    public float jumpTimer;
    float jumpTimerCounter;
    bool isJumping;
    //public LayerMask whatIsGround; -> If want add checks in OverlapCircle


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wallGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
      //Allow to jump
        Jump();

        speed = Mathf.Abs((int)rb.velocity.x);
        animator.SetFloat("Speed", speed);
   

        if (transform.position.x > 10) FindObjectOfType<GameManager>().LevelCompleted();
    }

    void FixedUpdate()
    {
      //Moving Horizontal
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * velocity, rb.velocity.y);

      //Change Faceing Side
        Flip();
    }

    void OnCollisionStay2D(Collision2D col)
    {
       
        if (col.gameObject.tag == "Platform" )
        {
            canJump = true;
            animator.SetBool("Ground", true);
        }

        if (col.gameObject.tag == "Wall")
        {

            canJump = true;
            rb.gravityScale = 0;
            rb.AddForce(axisY * -wallFriction * Time.deltaTime);

            if (col.transform.position.x < rb.position.x) wallSideL = false;
            else wallSideR = false;

        }

        if (col.gameObject.tag == "Enemy")
        {
            rb.AddForce(new Vector2(9f, 15f),ForceMode2D.Impulse);
            player.hp = -20;
        }

    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform" ) 
        {
            canJump = false;
            animator.SetBool("Ground", false);
        }

        if (col.gameObject.tag == "Wall")
        {
            canJump = false;
            rb.gravityScale = wallGravity;
            wallSideL = true;
            wallSideR = true;
        }
    }

    void Flip()
    {
      //Multiplaying scaler by negative to switch faceing side
        Vector3 Scaler = transform.localScale;
        if (faceingRight && moveInput < 0 || !faceingRight && moveInput > 0)
        {
            faceingRight = !faceingRight;
            Scaler.x *= -1;
        } 
        transform.localScale = Scaler;
    }

    void Jump()
    {
      //Using object FeetPos placed under player to check collision with sth
        isGrounded = Physics2D.OverlapCircle(feetPos.position, circleRadius);

      //Jump on hold Method 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpTimerCounter = jumpTimer;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimerCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimerCounter -= Time.deltaTime;
            }
            else isJumping = false;
        }

        if (Input.GetKeyUp(KeyCode.Space)) isJumping = false;
    }
}