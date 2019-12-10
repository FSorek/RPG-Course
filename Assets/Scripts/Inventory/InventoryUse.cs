using System;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class InventoryUse : MonoBehaviour
{
    private Inventory inventory;
    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        if(inventory.ActiveItem == null || inventory.ActiveItem.Actions == null)
            return;

        foreach (UseAction action in inventory.ActiveItem.Actions)
        {
            if(WasPressed(action.UseMode))
                action.TargetComponent.Use();
        }
    }

    private bool WasPressed(UseMode useMode)
    {
        switch (useMode)
        {
            case UseMode.LeftClick: return Input.GetMouseButtonDown(0);
            case UseMode.RightClick: return Input.GetMouseButtonDown(1);
        }
        return false;
    }
}