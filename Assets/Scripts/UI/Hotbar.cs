using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    private Inventory inventory;
    private Slot[] slots;

    private void OnEnable()
    {
        inventory = FindObjectOfType<Inventory>();
        inventory.ItemPickedUp += ItemPickedUp;
        slots = GetComponentsInChildren<Slot>();
    }

    private void ItemPickedUp(Item item)
    {
        Slot slot = FindNextOpenSlot();
        if (slot != null)
        {
            slot.SetItem(item);
        }
    }

    private Slot FindNextOpenSlot()
    {
        foreach (Slot slot in slots)
        {
            if (slot.IsEmpty)
                return slot;
        }

        return null;
    }
}