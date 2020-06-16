using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public const int DEFAULT_INVENTORY_SIZE = 29;
    public event Action<Item> ActiveItemChanged = delegate {  };
    public event Action<Item> ItemPickedUp = delegate {  };
    public event Action<int> OnItemChanged = delegate {  };
    
    
    [SerializeField] private Transform rightHand;
    private Item[] items = new Item[DEFAULT_INVENTORY_SIZE];
    private Transform itemRoot;

    public Item ActiveItem { get; private set; }
    public List<Item> Items => items.ToList();
    public int Count => items.Count(t => t != null);

    private void Awake()
    {
        itemRoot = new GameObject("Items").transform;
        itemRoot.transform.SetParent(transform);
    }

    public void Pickup(Item item, int? slot = null)
    {
        if (slot.HasValue == false)
            slot = FindFirstAvailableSlot();
        
        if(slot.HasValue == false)
            return;
        
        items[slot.Value] = item;
        item.transform.SetParent(itemRoot);
        ItemPickedUp(item);
        item.WasPickedUp = true;
        
        Equip(item);
    }

    private int? FindFirstAvailableSlot()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
                return i;
        }

        return null;
    }

    public void Equip(Item item)
    {
        if (ActiveItem != null)
        {
            ActiveItem.transform.SetParent(itemRoot);
            ActiveItem.gameObject.SetActive(false);
        }
        
        Debug.Log($"Equipped item {item.gameObject.name}");
        item.transform.SetParent(rightHand);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        ActiveItem = item;
        ActiveItemChanged(item);
    }

    public Item GetItemInSlot(int slot)
    {
        return items[slot];
    }

    public void Move(int sourceSlot, int destinationSlot)
    {
        var destinationItem = items[destinationSlot];
        items[destinationSlot] = items[sourceSlot];
        items[sourceSlot] = destinationItem;

        OnItemChanged(destinationSlot);
        OnItemChanged(sourceSlot);
    }
}