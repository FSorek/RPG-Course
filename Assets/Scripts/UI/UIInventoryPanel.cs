﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class UIInventoryPanel : MonoBehaviour
{
    public event Action OnSelectionChanged = delegate {  };
    private Inventory inventory;
    public UIInventorySlot[] Slots { get; private set; }
    public int SlotCount => Slots.Length;
    public UIInventorySlot Selected { get; private set; }

    private void Awake()
    {
        Slots = FindObjectsOfType<UIInventorySlot>()
            .OrderByDescending(t => t.SortIndex)
            .ThenBy(t => t.name)
            .ToArray();
        RegisterSlotsForClickCallback();
    }

    private void RegisterSlotsForClickCallback()
    {
        foreach (var slot in Slots)
        {
            slot.OnSlotClicked += HandleSlotClicked;
        }
    }

    private void HandleSlotClicked(UIInventorySlot slot)
    {
        if (Selected != null)
        {
            Swap(slot);
            Selected.BecomeUnselected();
            Selected = null;
        }
        else if(slot.IsEmpty == false)
        {
            Selected = slot;
            Selected.BecomeSelected();
        }
        OnSelectionChanged();
    }

    private void Swap(UIInventorySlot slot)
    {
        inventory.Move(GetSlotIndex(Selected), GetSlotIndex(slot));
    }

    private int GetSlotIndex(UIInventorySlot selected)
    {
        for (int i = 0; i < SlotCount; i++)
        {
            if (Slots[i] == selected)
                return i;
        }

        return -1;
    }

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