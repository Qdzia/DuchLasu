using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.AddModifire(newItem.trait01);
            damage.AddModifire(newItem.trait02);
        }

        if (oldItem != null)
        {
            armor.RemoveModifire(oldItem.trait01);
            damage.RemoveModifire(oldItem.trait02);
        }
       
    }
}
