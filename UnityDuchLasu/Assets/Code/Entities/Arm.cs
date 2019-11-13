using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public CapsuleCollider2D cap;
    public float ignoreTime;
    public PlayerController playerCon;
    bool isDodge;


    // Update is called once per frame
    void Update()
    {
        isDodge = playerCon.isDodge;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (isDodge && col.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(col, cap);
            Debug.Log("Off");
        }

        else if (!isDodge && col.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(col, cap, false);
            Debug.Log("On");
        }
            
    }
    
}

