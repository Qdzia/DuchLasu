using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Entity entity;
    public LayerMask ground;

    protected Rigidbody2D rb;
    protected float moveInput;
    public bool faceingRight = true;

    private void Awake()
    {
        rb = entity.rb;
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(entity.feetPos.position, 0.001f, ground);
    }
    public void Flip()
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
}
