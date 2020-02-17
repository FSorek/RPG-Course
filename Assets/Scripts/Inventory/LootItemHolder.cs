﻿using System;
using UnityEngine;

public class LootItemHolder : MonoBehaviour
{
    [SerializeField] private Transform itemTransform;
    [SerializeField] private float rotationSpeed = 1f;

    public void TakeItem(Item item)
    {
        item.transform.SetParent(itemTransform);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        item.gameObject.SetActive(true);
        item.WasPickedUp = false;
    }

    private void Update()
    {
        float amount = Time.deltaTime * rotationSpeed;
        itemTransform.Rotate(0, amount, 0);
    }
}
