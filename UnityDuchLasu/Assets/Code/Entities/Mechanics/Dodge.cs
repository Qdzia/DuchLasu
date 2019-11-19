using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{

    public Entity entity;

    public Rigidbody2D rb;
    bool isGrounded;
    bool faceingRight = true;
    public float speed;

    int dodgeTimer;
    public bool isDodge;
    public int dodgeTime;
    
    
    
    
    

    void DoDodge()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded && !isDodge)
        {
            CanHurt();
            dodgeTimer = dodgeTime;
            isDodge = true;
        }

        if (dodgeTimer > 0)
        {
            if (faceingRight) rb.velocity = Vector2.right * speed * 1.5f;
            else rb.velocity = Vector2.left * speed * 1.5f;
            dodgeTimer--;
            if (dodgeTimer == 1) CanHurt();
        }
        else isDodge = false;

    }

    public void CanHurt()
    {
        player.canHurt = !player.canHurt;
        Debug.Log("CanHurt");
    }
}
