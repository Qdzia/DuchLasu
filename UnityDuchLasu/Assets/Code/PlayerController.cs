using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
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
    int canJumpTimer = 0;
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
        
        speed = (int)rb.velocity.y;

        player.transform.rotation = Quaternion.Euler(Vector3.forward * 0);
       

        if (Input.GetKey(KeyCode.D)&& wallSideR)
        {
            if (rb.velocity.x < maxSpeed) rb.AddForce(axisX * movmentForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) && wallSideL)
        {
            if (rb.velocity.x > -maxSpeed) rb.AddForce(axisX * -movmentForce * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            jumpTimer = 10;
            


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
        }

        if (col.gameObject.tag == "Wall")
        {

            canJump = true;
            rb.gravityScale = 0;
            rb.AddForce(axisY * -wallFriction * Time.deltaTime);

            if (col.transform.position.x < rb.position.x) wallSideL = false;
            else wallSideR = false;

        }

    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform" ) 
        {
            canJump = false;
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
