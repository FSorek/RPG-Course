using System;
using UnityEngine;

public abstract class ItemComponent : MonoBehaviour
{
    private float lastUseTime;

    public abstract void Use();
    public bool CanUse => Time.deltaTime >= lastUseTime;
}