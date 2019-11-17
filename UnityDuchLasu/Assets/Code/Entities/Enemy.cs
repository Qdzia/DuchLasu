using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public CharacterStats Stats;
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "PlayerAttack")
        {
            Stats.TakeDamage(20);

        }
    }
    public override void Die()
    {
        Destroy(gameObject);
    }


}
