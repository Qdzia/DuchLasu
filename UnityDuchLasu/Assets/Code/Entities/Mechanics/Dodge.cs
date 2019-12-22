using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    public Entity entity;

    Rigidbody2D rb;
    public float speed;

    int dodgeTimer;
    public bool isDodge;
    public int dodgeTime;
    bool isGrounded;
    bool faceingRight;

    private void Awake()
    {
        rb = entity.rb;
    }

    public void DoDodge()
    {
        isGrounded = entity.controller.IsGrounded();
        faceingRight = entity.controller.faceingRight;

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDodge)
        {
            Physics2D.IgnoreLayerCollision(10, 10);
            dodgeTimer = dodgeTime;
            isDodge = true;
        }

        if (dodgeTimer > 0)
        {
            if (faceingRight) rb.velocity = Vector2.right * speed * 1.5f;
            else rb.velocity = Vector2.left * speed * 1.5f;
            
            dodgeTimer--;
            if (dodgeTimer == 1) Physics2D.IgnoreLayerCollision(10, 10,false);
        }
        else isDodge = false;

    }
}
