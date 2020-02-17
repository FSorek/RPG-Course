using UnityEngine;

public class Dead : IState
{
    const float DESPAWN_DELAY = 5f;
    
    private readonly Entity entity;
    private float despawnTime;

    public Dead(Entity entity)
    {
        this.entity = entity;
    }
    public void Tick()
    {
        if(Time.time >= despawnTime)
            Object.Destroy(entity.gameObject);
    }

    public void OnEnter()
    {
        despawnTime = Time.time + DESPAWN_DELAY;
    }

    public void OnExit()
    {
        
    }
}