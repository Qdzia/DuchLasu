using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = speed * transform.right;
        Invoke("Destroy", 3f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.tag != "Player")
        {
            Debug.Log("Hit: " + collision.gameObject.name);
            Destroy(gameObject);

        }
        
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
