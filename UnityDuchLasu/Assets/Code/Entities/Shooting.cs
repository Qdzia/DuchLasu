using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    public bool isPlayer = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")&&isPlayer)
        {
            Shoot();
        }

    }

    public void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);

    }
}
