using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPanel : MonoBehaviour
{
    private Inventory inventory;
    public UIInventorySlot[] Slots { get; private set; }

    private void Awake()
    {
        Slots = GetComponentsInChildren<UIInventorySlot>();
    }

    public int SlotCount => Slots.Length;

    public void Bind(Inventory inventory)
    {
        if (inventory != null)
        {
            inventory.ItemPickedUp -= HandleItemPickedUp;
            inventory.OnItemChanged -= HandleItemChanged;
        }
        
        this.inventory = inventory;
        
        if(inventory != null)
        {
            inventory.ItemPickedUp += HandleItemPickedUp;
            inventory.OnItemChanged += HandleItemChanged;
            RefreshSlots();
        }
        else
        {
            ClearSlots();
        }
    }

    private void HandleItemChanged(int slotNumber)
    {
        Slots[slotNumber].SetItem(inventory.GetItemInSlot(slotNumber));
    }

    private void ClearSlots()
    {
        foreach (var slot in Slots)
        {
            slot.Clear();
        }
    }

    private void RefreshSlots()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            var slot = Slots[i];

            if (inventory.Items.Count > i)
                slot.SetItem(inventory.Items[i]);
            else
                slot.Clear();
        }
    }

    private void HandleItemPickedUp(Item item)
    {
        RefreshSlots();
    }
}