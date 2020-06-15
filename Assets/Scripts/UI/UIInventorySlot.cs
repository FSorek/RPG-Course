using UnityEngine;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour
{
    [SerializeField] private Image image;
    public bool IsEmpty => Item == null;
    public Sprite Icon => image.sprite;
    public IItem Item { get; private set; }

    public void SetItem(IItem inventoryItem)
    {
        Item = inventoryItem;
        image.sprite = Item != null ? Item.Icon : null;
    }

    public void Clear()
    {
        Item = null;
    }
}