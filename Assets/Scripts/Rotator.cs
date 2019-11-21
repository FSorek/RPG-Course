using UnityEngine;

public class Rotator
{
    private readonly Player player;

    public Rotator(Player player)
    {
        this.player = player;
    }

    public void Tick()
    {
        var rotation = new Vector3(0, player.PlayerInput.MouseX, 0);
        player.transform.Rotate(rotation);
    }
}