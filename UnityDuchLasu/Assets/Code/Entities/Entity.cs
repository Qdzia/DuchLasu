using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public CharacterStats Stats;
    public virtual void Die()
    {
        Debug.Log(gameObject.name + " just Died!");
    }
}
