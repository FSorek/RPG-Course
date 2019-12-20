using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private List<IState> states = new List<IState>();
    private IState currentState;

    public void Add(IState state)
    {
        states.Add(state);
    }

    public void Tick()
    {
        currentState.Tick();
    }

    public void SetState(IState state)
    {
        if(currentState == state) return;
        
        currentState?.OnExit();
        currentState = state;
        currentState.OnEnter();
        Debug.Log($"Changed to {state}");
    }
}