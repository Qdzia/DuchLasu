using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Moe then one single ton of inventory");
            return;
        }

        instance = this;
    }
    #endregion

    public List<Item> items = new List<Item>();
    public GameObject inventoryUI;


    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;


    public void Add(Item item)
    {
        
        if (item.isInteractable) items.Add(item);
        if(onItemChangedCallBack != null) onItemChangedCallBack.Invoke();
        item.SetParameters();

    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallBack != null) onItemChangedCallBack.Invoke();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

}
