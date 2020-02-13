using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, ITakeHits
{
    [SerializeField] private int maxHealth = 5;
    public Action OnDied = delegate {  };

    public int Health { get; private set; }

    private void OnEnable()
    {
        Health = maxHealth;
    }

    public void TakeHit(int amount)
    {
        Health -= amount;
        if (Health <= 0)
            Die();
        else
        {
            HandleNonLethalHit();
        }
    }

    [ContextMenu("Take Lethal Damage")]
    private void TakeLethalDamage()
    {
        TakeHit(Health);
    }

    private void HandleNonLethalHit()
    {
        Debug.Log("Took non-lethal damage!");
    }

    private void Die()
    {
        OnDied.Invoke();
        Debug.Log("Died!");
    }
}