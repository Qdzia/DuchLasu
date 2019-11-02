using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image image;

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        image.sprite= item.icon;
        image.enabled = true;
    }
    public void ClearSlot()
    {
        item = null;
        image.sprite = null;
        image.enabled = false;
    }

    public void OnRemoveButtom()
    {
        Inventory.instance.Remove(item);
    }

    public void OnUseButtom()
    {
        item.Use();
    }

}
