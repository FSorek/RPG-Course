using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPanel : MonoBehaviour
{
    public UIInventorySlot[] Slots { get; private set; }

    private void Awake()
    {
        Slots = GetComponentsInChildren<UIInventorySlot>();
    }

    public int SlotCount => Slots.Length;

    public void Bind(Inventory inventory)
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
}