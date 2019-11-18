using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Enemy
{
    public Shooting rifle;
    public Transform sensor;
    public int timeToShoot = 20;
    int timer = 0;

    void Update()
    {
        Aiming();
    }

    public void Aiming()
    {
        RaycastHit2D hitRight = Physics2D.Raycast(rifle.FirePoint.position, transform.right);

        Sensor();
        if (timer > 0) timer--;

        if (timer < 1 && hitRight && hitRight.transform.tag == "Player")
        {    
           rifle.Shoot();
           timer = timeToShoot;
        }
        
    }

    void Sensor()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(sensor.position, -transform.right);
        if (hitLeft && hitLeft.transform.tag == "Player")
            transform.Rotate(0f, 180f, 0f);
    }
}
