using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler
{
    public event Action<UIInventorySlot> OnSlotClicked = delegate{};
    [SerializeField] private Image image;
    [SerializeField] private int sortIndex;
    public bool IsEmpty => Item == null;
    public Sprite Icon => image.sprite;
    public IItem Item { get; private set; }
    public bool IconImageEnabled => image.enabled;
    public int SortIndex => sortIndex;

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

    public void OnPointerDown(PointerEventData eventData)
    {
        OnSlotClicked(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var droppedOnSlot = eventData.pointerCurrentRaycast.gameObject?.GetComponentInParent<UIInventorySlot>();
        if(droppedOnSlot != null)
            droppedOnSlot.OnPointerDown(eventData);
        else
            OnPointerDown(eventData);
    }

    public void OnDrag(PointerEventData eventData){}
}