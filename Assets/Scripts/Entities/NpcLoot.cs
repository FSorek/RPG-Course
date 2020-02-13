using System;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class NpcLoot : MonoBehaviour
{
    [SerializeField] private Item[] itemPrefabs;
    private Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
        foreach (var itemPrefab in itemPrefabs)
        {
            var itemInstance = Instantiate(itemPrefab);
            inventory.Pickup(itemInstance);
        }
    }
}