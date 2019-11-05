using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public GameObject itemParent;
    InventorySlot[] slots;

    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += UpdateEquipment;
        slots = itemParent.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateEquipment(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
            slots[(int)newItem.equipSlot].AddItem(newItem);

        else
            slots[(int)oldItem.equipSlot].ClearSlot();

    }

}
