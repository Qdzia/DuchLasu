using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewFinder : MonoBehaviour
{

    public float rotationOffSet = 0;
    public Player player;
    Vector3 tr;

    void Update()
    {
        transform.position = player.transform.position;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float RotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, RotZ + rotationOffSet);

        
        
    }

    
}

