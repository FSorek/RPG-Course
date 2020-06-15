using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPanel : MonoBehaviour
{
    private UIInventorySlot[] slots;

    private void Awake()
    {
        slots = GetComponentsInChildren<UIInventorySlot>();
    }

    public int SlotCount => slots.Length;
}