using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public BoxCollider2D myBoxCollider;
    public Item item;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(col, myBoxCollider);
        }

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            PickUp();
            Destroy(gameObject);
        }
    }

    void PickUp()
    {
        Inventory.instance.Add(item);
    
    }

    void Remove()
    {

    }

}
