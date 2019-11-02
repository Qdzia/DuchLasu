using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item") ]
public class Item : ScriptableObject
{
    public string itemName = "";
    public Sprite icon = null;
    public bool isInteractable = true;

    public virtual void Use()
    {
        //somthing maight happend

        Debug.Log("use: " + itemName);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}

