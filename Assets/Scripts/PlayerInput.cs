using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IPlayerInput
{
    public static IPlayerInput Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public float Vertical => Input.GetAxis("Vertical");
    public float Horizontal => Input.GetAxis("Horizontal");
    public float MouseX => Input.GetAxis("Mouse X");
    public event Action<int> HotkeyPressed = delegate { };
    public event Action MoveTypeToggle = delegate {  };

    private void Update()
    {
        for (int i = 0; i < 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                HotkeyPressed(i);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            MoveTypeToggle();
    }

    public bool PausePressed => Input.GetKeyDown(KeyCode.Escape);
    public Vector2 MousePosition => Input.mousePosition;
}