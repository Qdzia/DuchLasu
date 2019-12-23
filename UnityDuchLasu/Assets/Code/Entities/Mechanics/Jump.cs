using UnityEngine;

public class Jump : MonoBehaviour, ISkill
{
    public Entity entity;


    public int extraJumpsNumber;
    public float jumpForce;
    public float jumpTimer;
    public int extraJumps;

    Rigidbody2D rb;
    Transform feetPos;
 
    float jumpTimerCounter;
    bool isJumping;
    bool isGrounded;

    private void Awake()
    {
        rb = entity.rb;
        feetPos = entity.feetPos;   
    }
    //In cause of random duble jumpiung add layer mask to overlapCircle
    public void Active()
    {

        //Using object FeetPos placed under player to check collision with sth
        isGrounded = entity.controller.IsGrounded();

        if (isGrounded)
            extraJumps = extraJumpsNumber;
        
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
}
