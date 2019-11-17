using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public int hp;
    public bool canHurt = true;

    public override void Die()
    {
        Destroy(gameObject);
    }
}
