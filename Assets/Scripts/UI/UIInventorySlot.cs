using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour, IPointerClickHandler
{
    public event Action<UIInventorySlot> OnSlotClicked = delegate{};
    [SerializeField] private Image image;
    public bool IsEmpty => Item == null;
    public Sprite Icon => image.sprite;
    public IItem Item { get; private set; }
    public bool IconImageEnabled => image.enabled;

    public void SetItem(IItem inventoryItem)
    {
        Item = inventoryItem;
        image.sprite = Item != null ? Item.Icon : null;
        image.enabled = Item != null;
    }

    public void Clear()
    {
        Item = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnSlotClicked(this);
    }
}