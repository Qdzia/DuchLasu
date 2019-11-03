using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public GameObject itemParent;
    InventorySlot[] slots;
    Inventory inventory;
    Equipment[] equipments;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateEquipment;
        
        slots = itemParent.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateEquipment()
    {
        equipments = EquipmentManager.instance.currentEquiment;

        for (int i = 0; i < slots.Length; i++)
        {
            if (equipments[i]!=null)
            {
                slots[i].AddItem(equipments[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }

}
