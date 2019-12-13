using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public IPlayerInput PlayerInput { get; set; } = new PlayerInput();

    private CharacterController chatacterController;
    private IMover mover;
    private Rotator rotator;

    private void Awake()
    {
        chatacterController = GetComponent<CharacterController>();
        mover = new Mover(this);
        rotator = new Rotator(this);
        PlayerInput.MoveTypeToggle += MoveTypeToggle;
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
        mover.Tick();
        rotator.Tick();
        PlayerInput.Tick();
    }
}