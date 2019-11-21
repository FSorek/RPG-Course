using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> items = new List<Item>();
    private Transform itemRoot;

    private void Awake()
    {
        itemRoot = new GameObject("Items").transform;
        itemRoot.transform.SetParent(transform);
    }

    public void Pickup(Item item)
    {
        items.Add(item);
        item.transform.SetParent(itemRoot);

        Equip(item);
    }

    private void Equip(Item item)
    {
        Debug.Log($"Equipped item {item.gameObject.name}");
    }
}