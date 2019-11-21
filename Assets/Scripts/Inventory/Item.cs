using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    private bool wasPickedUp;

    private void OnTriggerEnter(Collider other)
    {
        if(wasPickedUp)
            return;

        var inventory = other.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.Pickup(this);
            wasPickedUp = true;
        }
    }

    private void OnValidate()
    {
        var collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }
}