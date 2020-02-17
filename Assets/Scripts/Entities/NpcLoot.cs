using System;
using UnityEngine;
using Object = System.Object;

[RequireComponent(typeof(Inventory))]
public class NpcLoot : MonoBehaviour
{
    [SerializeField] private Item[] itemPrefabs;
    private Inventory inventory;
    private EntityStateMachine entityStateMachine;

    private void Start()
    {
        entityStateMachine = GetComponent<EntityStateMachine>();
        entityStateMachine.OnEntityStateChanged += HandleEntityStateChanged;
        
        inventory = GetComponent<Inventory>();
        foreach (var itemPrefab in itemPrefabs)
        {
            var itemInstance = Instantiate(itemPrefab);
            inventory.Pickup(itemInstance);
        }
    }

    private void HandleEntityStateChanged(IState state)
    {
        Debug.Log($"HESC {state.GetType()}");
        if (state is Dead)
        {
            DropLoot();
        }
    }

    private void DropLoot()
    {
        foreach (var item in inventory.Items)
        {
            LootSystem.Drop(item, transform);
            //var lootItemHolder = FindObjectOfType<LootItemHolder>();
            //lootItemHolder.TakeItem(item);
        }
        inventory.Items.Clear();
    }
}