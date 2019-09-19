using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tr;
    public GameObject player;
    public float movmentForce = 70;
    public float speed = 0;
    public float maxSpeed = 1000;
    public int jumpDuration = 50;
    public float jumpForce = 1;

    int jumpTimer = 0;
    bool canJump = false;
    Vector2 axisX = new Vector2(1f, 0f);
    Vector2 axisY = new Vector2(0f, 1f);
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        speed = rb.velocity.x;

        player.transform.rotation = Quaternion.Euler(Vector3.forward * 0);

        if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x < maxSpeed) rb.AddForce(axisX * movmentForce);
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.x > -maxSpeed) rb.AddForce(axisX * -movmentForce);
        }

        if (Input.GetKeyDown(KeyCode.Space)&& canJump)
        {  
            jumpTimer = jumpDuration;
            Debug.Log("jump");
        }
        if (jumpTimer > 0)
        {
            rb.AddForce(axisY * jumpForce*jumpTimer);
            jumpTimer--;
            canJump = false;
        }



    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        if (col.gameObject.tag == "Platform" || col.gameObject.tag == "Wall") canJump = true;
      
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform" || col.gameObject.tag == "Wall") canJump = false;
        Debug.Log("OnCollisionExit2D");
    }
}
