using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public int trait01;
    public int trait02;

    public bool isEquip;

    public EquipmentSlot equipSlot;

    public override void Use()
    {
        base.Use();
        if (!isEquip)
        {
            EquipmentManager.instance.Equip(this);
            isEquip = true;
        }
        else
        {
            EquipmentManager.instance.Unequip((int)this.equipSlot);
            isEquip = false;
        }
    }

    public override void SetParameters()
    {
        isEquip = false;
    }
}

public enum EquipmentSlot { Weapon, Coat, Trinket, Soul }
