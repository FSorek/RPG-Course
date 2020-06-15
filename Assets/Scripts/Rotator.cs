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
        if(Pause.Active)
            return;
        
        var rotation = new Vector3(0, PlayerInput.Instance.MouseX, 0);
        player.transform.Rotate(rotation);
    }
}