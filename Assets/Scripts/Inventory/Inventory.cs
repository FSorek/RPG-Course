using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event Action<Item> ActiveItemChanged = delegate {  };
    public event Action<Item> ItemPickedUp = delegate {  };
    
    
    [SerializeField] private Transform rightHand;
    private List<Item> items = new List<Item>();
    private Transform itemRoot;
    
    public Item ActiveItem { get; private set; }

    private void Awake()
    {
        itemRoot = new GameObject("Items").transform;
        itemRoot.transform.SetParent(transform);
    }

    public void Pickup(Item item)
    {
        items.Add(item);
        item.transform.SetParent(itemRoot);
        ItemPickedUp(item);
        item.WasPickedUp = true;
        
        Equip(item);
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

}