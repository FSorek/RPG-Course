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
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            mover = new Mover(this);
        if(Input.GetKeyDown(KeyCode.Alpha2))
            mover = new NavmeshMover(this);
        mover.Tick();
        rotator.Tick();
    }
}