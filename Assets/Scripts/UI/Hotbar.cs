using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    private Inventory inventory;
    private Slot[] slots;
    private Player player;

    private void OnEnable()
    {
        player = FindObjectOfType<Player>();
        PlayerInput.Instance.HotkeyPressed += HotkeyPressed;
        
        inventory = FindObjectOfType<Inventory>();
        inventory.ItemPickedUp += ItemPickedUp;
        slots = GetComponentsInChildren<Slot>();
    }

    private void OnDisable()
    {
        PlayerInput.Instance.HotkeyPressed -= HotkeyPressed;
        inventory.ItemPickedUp -= ItemPickedUp;
    }

    private void HotkeyPressed(int index)
    {
        if(index >= slots.Length || index < 0)
            return;
        
        if (slots[index].IsEmpty == false)
            inventory.Equip(slots[index].Item);
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