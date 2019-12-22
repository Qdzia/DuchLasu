using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : Controller
{
    public Jump jump;
    public Dodge dodge;

    public CapsuleCollider2D cap;
    
    public float velocity;
    bool isCrouch = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Allow to jump
        if (Input.GetKeyDown(KeyCode.Space)) jump.DoJump(0);
        else if (Input.GetKey(KeyCode.Space)) jump.DoJump(1);
        else if (Input.GetKeyUp(KeyCode.Space)) jump.DoJump(2);

        Crouch();
       
    }

    void FixedUpdate()
    {
        //Moving Horizontal
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * velocity, rb.velocity.y);

        dodge.DoDodge();

        //Change Faceing Side
        Flip();
    }


    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) )
        {
            cap.size = new Vector2(cap.size.x, cap.size.y/2);
            cap.offset = new Vector2(cap.offset.x, cap.offset.y * 4);
            Debug.Log("crouch");
            isCrouch = true;
        }

        if ((Input.GetKeyUp(KeyCode.LeftControl)) && isCrouch)
        {
            cap.size = new Vector2(cap.size.x, cap.size.y * 2);
            cap.offset = new Vector2(cap.offset.x, cap.offset.y/4);
            Debug.Log("!!!crouch");
            isCrouch = false;
        }

    }
   
}