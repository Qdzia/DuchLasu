using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
   
    public int hp
    {
        set
        {
            _hp += value;
            if (_hp <= 0) FindObjectOfType<GameManager>().EndOfGame();
        }
        get { return _hp; }
    }
    int _hp = 100;

    public bool canHurt = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
