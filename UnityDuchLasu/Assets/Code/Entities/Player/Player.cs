using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public int hp;
    public bool canHurt = true;

    public ISkill Jump, Dodge;

    private void Awake()
    {
        Jump = GetComponent<Jump>();
        Dodge = GetComponent<Dodge>();
    }
    void Update()
    {
        Jump.Active();
        Dodge.Active();
    }
    public override void Die()
    {
        Destroy(gameObject);
    }
}
