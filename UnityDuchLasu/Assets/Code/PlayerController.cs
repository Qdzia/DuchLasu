using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Player player;
    public Animator animator;
    public Transform feetPos;
    public LayerMask mask;

    public int speed = 0;
    public float velocity;
    public float wallFriction;
    public int extraJumpsNumber;
    public float circleRadius;
    public float jumpForce;
    public float jumpTimer;
    public int extraJumps;

    float moveInput;
    bool faceingRight = true;
    bool isGrounded;
    float jumpTimerCounter;
    bool isJumping;
    int wallID;
    bool blockDir;
    
    //public LayerMask whatIsGround; -> If want add checks in OverlapCircle


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if(BlocDir())rb.velocity = new Vector2(moveInput * velocity, rb.velocity.y);

        //Change Faceing Side
        Flip();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            rb.AddForce(new Vector2(9f, 15f), ForceMode2D.Impulse);
            player.hp = -20;
        }

        //Add extra jump after colision with wall, check id to not allow on second jump on the same wall
        if (col.gameObject.tag == "Wall")
        {
            blockDir = true;

            if (wallID != col.gameObject.GetInstanceID() && extraJumps==0)
            {
                extraJumps++;
                Debug.Log("nierówne");
                wallID = col.gameObject.GetInstanceID();
            }

            Debug.Log("zmien sciane");
        }

    }

    void OnCollisionStay2D(Collision2D col)
    {
        //Stable velocity with wall contact
        if (col.gameObject.tag == "Wall")
        {
            if (rb.velocity.y < -wallFriction) rb.velocity = Vector2.down * wallFriction;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall") blockDir = false;
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
        isGrounded = Physics2D.OverlapCircle(feetPos.position, circleRadius,mask);
        if (isGrounded)
        {
            extraJumps = extraJumpsNumber;
            wallID = 0;
        } 

        //Jump on hold Method + multiple Jump 
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpTimerCounter = jumpTimer;
            Debug.Log("Jump");
            extraJumps--;
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

    bool BlocDir()
    {
        if (blockDir)
        {
            if (faceingRight && moveInput > 0) return false;
            else if(!faceingRight && moveInput < 0) return false;
        }

        return true;
    }
}