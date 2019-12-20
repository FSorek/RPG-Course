using UnityEngine;

public class Idle : IState
{
    public void Tick()
    {
        Debug.Log("Idling.");
    }

    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
        
    }
}