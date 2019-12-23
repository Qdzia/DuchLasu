using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour, ISkill
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

    public void Active()
    {
        isGrounded = entity.controller.IsGrounded();
        faceingRight = entity.controller.faceingRight;

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDodge && isGrounded)
        {
            Physics2D.IgnoreLayerCollision(10, 10);
            dodgeTimer = dodgeTime;
            isDodge = true;
        }

        if (dodgeTimer > 0)
        {
            if (faceingRight) rb.AddForce(Vector2.right * speed * 1.5f, ForceMode2D.Impulse);
            else rb.AddForce(Vector2.left * speed * 1.5f, ForceMode2D.Impulse);

            dodgeTimer--;
            if (dodgeTimer == 1) Physics2D.IgnoreLayerCollision(10, 10,false);
        }
        else isDodge = false;

    }
}
