using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Enemy
{
    public Shooting rifle;
    public int timeToShoot = 20;
    int timer = 0;

    void Update()
    {
        Aiming();
    }

    public void Aiming()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rifle.FirePoint.position, transform.right);
        if (timer > 0) timer--;

        if (hitInfo && hitInfo.transform.tag == "Player"&& timer < 1)
        {
            rifle.Shoot();
            Debug.Log("strzał");
            timer = timeToShoot;
        }
        
    }
}
