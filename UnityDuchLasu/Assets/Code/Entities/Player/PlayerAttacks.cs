using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public GameObject AttackZone;
    bool isActive;
    public float attackTimer = 100f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ActiveAttack();
            isActive = !isActive;
            Invoke("ActiveAttack", 0.1f);
            attackTimer = 0f;
        }
        if (attackTimer < 100f) attackTimer++;
    }

    void ActiveAttack()
    {
        AttackZone.SetActive(isActive);
    }
    
}
