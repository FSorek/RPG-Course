using UnityEngine;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour
{
    [SerializeField] private Image image;
    private IItem item;
    public bool IsEmpty => item == null;
    public Sprite Icon => image.sprite;

    public void SetItem(IItem inventoryItem)
    {
        item = inventoryItem;
        image.sprite = item != null ? item.Icon : null;
    }

    public void Clear()
    {
        item = null;
    }
}