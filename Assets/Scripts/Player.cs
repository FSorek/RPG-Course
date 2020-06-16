using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController chatacterController;
    private IMover mover;
    private Rotator rotator;
    private Inventory inventory;

    public Stats Stats { get; private set; }

    private void Awake()
    {
        chatacterController = GetComponent<CharacterController>();
        mover = new Mover(this);
        rotator = new Rotator(this);
        inventory = GetComponent<Inventory>();
        
        PlayerInput.Instance.MoveTypeToggle += MoveTypeToggle;
        
        Stats = new Stats();
        Stats.Bind(inventory);
    }

    private void MoveTypeToggle()
    {
        if(mover is NavmeshMover)
            mover = new Mover(this);
        else
            mover = new NavmeshMover(this);
    }

    // Update is called once per frame
    private void Update()
    {
        if(Pause.Active)
            return;
        
        mover.Tick();
        rotator.Tick();
    }
}