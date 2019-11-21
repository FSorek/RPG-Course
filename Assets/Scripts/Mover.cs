﻿using UnityEngine;
using UnityEngine.AI;

public class Mover : IMover
{
    private readonly Player player;
    private readonly CharacterController characterController;

    public Mover(Player player)
    {
        this.player = player;
        characterController = player.GetComponent<CharacterController>();
        player.GetComponent<NavMeshAgent>().enabled = false;
    }

    public void Tick()
    {
        Vector3 moveInput = new Vector3(player.PlayerInput.Horizontal,0, player.PlayerInput.Vertical);
        Vector3 movement = player.transform.rotation * moveInput;
        characterController.SimpleMove(movement);
    }
}