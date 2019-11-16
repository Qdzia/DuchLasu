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
    public CapsuleCollider2D cap;

    public int speed = 0;
    public float velocity;
    public float wallFriction;
    public int extraJumpsNumber;
    public float circleRadius;
    public float jumpForce;
    public float jumpTimer;
    public int extraJumps;
    public int dodgeTime;
    public bool isDodge;

    float moveInput;
    bool faceingRight = true;
    bool isGrounded;
    float jumpTimerCounter;
    bool isJumping;
    int wallID;
    bool blockDir;
    bool isCrouch = false;
    int dodgeTimer;
    


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
        Dodge();
        Jump();

        Crouch();
        

        speed = Mathf.Abs((int)rb.velocity.x);
        animator.SetFloat("Speed", speed);
    }

    void FixedUpdate()
    {
        //Moving Horizontal
        moveInput = Input.GetAxis("Horizontal");
        if (BlocDir()) rb.velocity = new Vector2(moveInput * velocity, rb.velocity.y);

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

            if (wallID != col.gameObject.GetInstanceID() && extraJumps == 0)
            {
                extraJumps++;
                wallID = col.gameObject.GetInstanceID();
            }
            
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
        //Multiplaying scaler by negative to switch faceing side (changing scale old method to change faceing)
        //Vector3 Scaler = transform.localScale;
        if (faceingRight && moveInput < 0 || !faceingRight && moveInput > 0)
        {
            faceingRight = !faceingRight;
            transform.Rotate(0f, 180f, 0f);
           // Scaler.x *= -1;
        }
        //transform.localScale = Scaler;
    }

    void Jump()
    {
        //Using object FeetPos placed under player to check collision with sth
        isGrounded = Physics2D.OverlapCircle(feetPos.position, circleRadius, mask);
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
        if (isDodge) return false;

        if (blockDir)
        {
            if (faceingRight && moveInput > 0) return false;
            else if (!faceingRight && moveInput < 0) return false;
        }

        return true;
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            cap.size = new Vector2(cap.size.x, cap.size.y/2);
            cap.offset = new Vector2(cap.offset.x, cap.offset.y * 4);
            Debug.Log("crouch");
            isCrouch = true;
        }

        if ((Input.GetKeyUp(KeyCode.LeftControl) || isJumping) && isCrouch)
        {
            cap.size = new Vector2(cap.size.x, cap.size.y * 2);
            cap.offset = new Vector2(cap.offset.x, cap.offset.y/4);
            Debug.Log("!!!crouch");
            isCrouch = false;
        }

    }

    void Dodge()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded && !isDodge)
        {
            CanHurt();
            dodgeTimer = dodgeTime;
            isDodge = true;
        }

        if (dodgeTimer > 0)
        {
            if(faceingRight)rb.velocity = Vector2.right * velocity * 1.5f;
            else rb.velocity = Vector2.left * velocity * 1.5f;
            dodgeTimer--;
            if (dodgeTimer == 1) CanHurt();
        }
        else isDodge = false;

    }

    public void CanHurt()
    {
        player.canHurt = !player.canHurt;
        Debug.Log("CanHurt");
    }



    
}