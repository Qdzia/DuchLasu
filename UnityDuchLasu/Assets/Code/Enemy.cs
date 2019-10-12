using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    // Start is called before the first frame update
    public int hp
    {
        set
        {
            _hp += value;
            if (_hp <= 0) Die();
        }
        get { return _hp; }
    }
    int _hp = 40;


    public bool playerAttackTimer = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "ViewFinder" && Input.GetMouseButtonDown(0) && playerAttackTimer)
        {
            hp = -20;
            playerAttackTimer = false;
            Invoke("Attack", 1f);
            Debug.Log("attack");
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }

    public void Attack()
    {
        playerAttackTimer = true;
    }

}
