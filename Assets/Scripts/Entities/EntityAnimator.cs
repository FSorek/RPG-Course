using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Entity))]
public class EntityAnimator : MonoBehaviour
{
    private Animator animator;
    private Entity entity;
    private static readonly int Die = Animator.StringToHash("Die");

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        entity = GetComponent<Entity>();
        entity.OnDied += () => animator.SetBool(Die, true);
    }
}
