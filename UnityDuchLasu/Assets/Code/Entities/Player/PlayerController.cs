using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : Controller
{
    public float velocity;

    //bool isCrouch = false;
    //public CapsuleCollider2D cap;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Moving Horizontal
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * velocity, rb.velocity.y);


        //Change Faceing Side
        Flip();
    }


    //void Crouch()
    //{
    //    if (Input.GetKeyDown(KeyCode.LeftControl) )
    //    {
    //        cap.size = new Vector2(cap.size.x, cap.size.y/2);
    //        cap.offset = new Vector2(cap.offset.x, cap.offset.y * 4);
    //        Debug.Log("crouch");
    //        isCrouch = true;
    //    }

    //    if ((Input.GetKeyUp(KeyCode.LeftControl)) && isCrouch)
    //    {
    //        cap.size = new Vector2(cap.size.x, cap.size.y * 2);
    //        cap.offset = new Vector2(cap.offset.x, cap.offset.y/4);
    //        Debug.Log("!!!crouch");
    //        isCrouch = false;
    //    }

    //}
   
}