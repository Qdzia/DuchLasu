using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public CharacterStats Stats;
    public Rigidbody2D rb;
    public Transform feetPos;
    public Controller controller;

    public virtual void Die()
    {
        Debug.Log(gameObject.name + " just Died!");
    }
}
