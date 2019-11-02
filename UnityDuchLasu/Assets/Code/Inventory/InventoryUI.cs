using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject itemParent;
    public GameObject equipParent;
    Inventory inventory;
    InventorySlot[] slots;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemParent.GetComponentsInChildren<InventorySlot>();
    }
    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }

    public void UpdateEquipment()
    {
        if (System.Enum.GetNames(typeof(EquipmentSlot)).Length == equipParent.transform.childCount)
        {
            Debug.Log("children: " + equipParent.transform.childCount);

        }
    }

}
