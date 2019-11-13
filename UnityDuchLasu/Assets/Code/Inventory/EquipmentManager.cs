using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static EquipmentManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Moe then one single ton of EquipmentManager");
            return;
        }

        instance = this;
    }
    #endregion

    Inventory inventory;
    public Equipment[] currentEquiment;
    int numSlots;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    void Start()
    {
        inventory = Inventory.instance;
        numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquiment = new Equipment[numSlots];

    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        Equipment oldItem = null;

        if (currentEquiment[slotIndex] != null)
        {
            oldItem = currentEquiment[slotIndex];
            inventory.Add(oldItem);
        }
        newItem.RemoveFromInventory();
        currentEquiment[slotIndex] = newItem;

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
    }

    public void Unequip(int slotIdnex)
    {
        if (currentEquiment[slotIdnex] != null)
        {
            Equipment oldItem = currentEquiment[slotIdnex];
            inventory.Add(oldItem);

            currentEquiment[slotIdnex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i > numSlots; i++)
        {
            Unequip(i);
        }
    }
    
}
