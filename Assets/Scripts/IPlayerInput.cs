using System;
using UnityEngine;

public interface IPlayerInput
{
    event Action<int> HotkeyPressed;
    event Action MoveTypeToggle;
    float Vertical { get; }
    float Horizontal { get; }
    float MouseX { get; }
    bool PausePressed { get; }
    Vector2 MousePosition { get; }
}