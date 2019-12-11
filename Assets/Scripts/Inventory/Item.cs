using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    private bool wasPickedUp;
    [SerializeField] private CrosshairDefinition crosshairDefinition;
    [SerializeField] private UseAction[] actions = new UseAction[0];
    public UseAction[] Actions => actions;

    public CrosshairDefinition CrosshairDefinition => crosshairDefinition;

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