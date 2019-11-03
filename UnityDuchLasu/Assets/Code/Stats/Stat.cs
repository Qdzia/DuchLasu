using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Stat
{
    [SerializeField]
    private int baseValue =0;

    private List<int> modifires = new List<int>();
    public int GetValue()
    {
        int finalValue = baseValue;
        modifires.ForEach(x => finalValue += x);
        Debug.Log("modyfikator: " + finalValue);
        return finalValue;
    }

    public void AddModifire(int modifire)
    {
        if (modifire != 0)
        {
            modifires.Add(modifire);
        }
    }

    public void RemoveModifire(int modifire)
    {
        if (modifire != 0)
        {
            modifires.Remove(modifire);
        }
    }

}
