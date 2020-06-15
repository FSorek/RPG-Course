using UnityEngine;

public class UIInventorySlot : MonoBehaviour
{
    private Item item;
    public bool IsEmpty => item == null;

    public void SetItem(Item inventoryItem)
    {
        item = inventoryItem;
    }

    public void Clear()
    {
        item = null;
    }
}