using UnityEngine;


public class Jump : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform feetPos;

    public int extraJumpsNumber;
    public float circleRadius;
    public float jumpForce;
    public float jumpTimer;
    public int extraJumps;

    float jumpTimerCounter;
    bool isJumping;
    bool isGrounded;
    

    public void DoJump(int input)
    {

        //Using object FeetPos placed under player to check collision with sth
        isGrounded = Physics2D.OverlapCircle(feetPos.position, circleRadius);

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
