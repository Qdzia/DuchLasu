using UnityEngine;


public class Jump : MonoBehaviour
{
    public Entity entity;
    public LayerMask mask;

    public int extraJumpsNumber;
    public float jumpForce;
    public float jumpTimer;
    public int extraJumps;

    Rigidbody2D rb;
    Transform feetPos;
 
    public float circleRadius;
    float jumpTimerCounter;
    bool isJumping;
    bool isGrounded;

    private void Awake()
    {
        rb = entity.rb;
        feetPos = entity.feetPos;

        
    }
    //In cause of random duble jumpiung add layer mask to overlapCircle
    public void DoJump(int input)
    {

        //Using object FeetPos placed under player to check collision with sth
        isGrounded = entity.controller.IsGrounded();

        if (isGrounded)
            extraJumps = extraJumpsNumber;
        
        //Jump on hold Method + multiple Jump 
        if (input==(int)space.down && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpTimerCounter = jumpTimer;
            extraJumps--;
        }

        if (input == (int)space.hold && isJumping)
        {
            if (jumpTimerCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimerCounter -= Time.deltaTime;
            }
            else isJumping = false;
        }

        if (input == (int)space.up) isJumping = false;

    }
    enum space { down, hold, up}
}
