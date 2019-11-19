using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public IPlayerInput PlayerInput { get; set; } = new PlayerInput();

    private CharacterController chatacterController;
    
    private void Awake()
    {
        chatacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 moveInput = new Vector3(PlayerInput.Horizontal,0, PlayerInput.Vertical);
        Vector3 movement = transform.rotation * moveInput;
        chatacterController.SimpleMove(movement);
    }
}

public class PlayerInput : IPlayerInput
{
    public float Vertical => Input.GetAxis("Vertical");
    public float Horizontal => Input.GetAxis("Horizontal");
}

public interface IPlayerInput
{
    float Vertical { get; }
    float Horizontal { get; }
}
