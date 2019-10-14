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
    public float jumpForce = 0f;
    public float jumpLowToMax = 0f;
    public bool canJump = false;
    public float wallFriction=0f;
    

    public bool wallSideL = true;
    public bool wallSideR = true;
    float jumpTimer = 0f;
    float wallGravity = 0f;
    Vector2 axisX = new Vector2(1f, 0f);
    Vector2 axisY = new Vector2(0f, 1f);
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wallGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Abs((int)rb.velocity.x);
        animator.SetFloat("Speed", speed);

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            jumpTimer = 10;
            
        }

        if (transform.position.x > 10) FindObjectOfType<GameManager>().LevelCompleted();
    }

    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) && wallSideR)
        {
            if (rb.velocity.x < maxSpeed) rb.AddForce(axisX * movmentForce * Time.deltaTime);
            spriteRen.flipX = false;
        }

        if (Input.GetKey(KeyCode.A) && wallSideL)
        {
            if (rb.velocity.x > -maxSpeed) rb.AddForce(axisX * -movmentForce * Time.deltaTime);
            spriteRen.flipX = true;
        }

        if (Input.GetKey(KeyCode.Space) && jumpTimer > 0)
        {
            rb.AddForce(axisY * jumpForce * Time.deltaTime);
            jumpTimer--;
        }
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
}
