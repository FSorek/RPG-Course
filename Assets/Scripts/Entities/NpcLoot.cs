using System;
using UnityEngine;

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
            item.transform.SetParent(null);
            item.transform.position = transform.position + transform.right;
            item.gameObject.SetActive(true);
        }
        inventory.Items.Clear();
    }
}