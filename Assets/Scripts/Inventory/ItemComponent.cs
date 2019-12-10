using System;
using UnityEngine;

public abstract class ItemComponent : MonoBehaviour
{
    protected float nextUseTime;

    public abstract void Use();
    public bool CanUse => Time.deltaTime >= nextUseTime;
}