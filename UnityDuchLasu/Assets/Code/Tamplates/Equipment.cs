using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public int trait01;
    public int trait02;

    public EquipmentSlot equipSlot;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
    }
}

public enum EquipmentSlot { Weapon, Coat, Trinket, Soul }
