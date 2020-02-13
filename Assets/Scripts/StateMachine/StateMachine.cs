using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private List<StateTransition> stateTransitions = new List<StateTransition>();
    private List<StateTransition> anyStateTransition = new List<StateTransition>();

    private IState currentState;
    public IState CurrentState => currentState;

    public void Tick()
    {
        StateTransition transition = CheckForTransition();
        if (transition != null)
        {
            SetState(transition.To);
        }
        
        currentState.Tick();
    }

    private StateTransition CheckForTransition()
    {
        foreach (var transition in anyStateTransition)
        {
            if (transition.Condition())
                return transition;
        }
        
        foreach (var transition in stateTransitions)
        {
            if (transition.From == currentState && transition.Condition())
                return transition;
        }

        return null;
    }

    public void AddTransition(IState from, IState to, Func<bool> condition)
    {

        var transition = new StateTransition(from, to, condition);
        stateTransitions.Add(transition);
    }
    public void AddAnyTransition(IState to, Func<bool> condition)
    {
        var transition = new StateTransition(null, to, condition);
        anyStateTransition.Add(transition);
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