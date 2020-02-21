using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateMachine : MonoBehaviour
{
    private StateMachine stateMachine;

    private void Awake()
    {
        stateMachine = new StateMachine();
        
        var menu = new Menu();
        var loading = new LoadLevel();
        var play = new Play();
        var pause = new Pause();
        
        stateMachine.SetState(loading);
        
        stateMachine.AddTransition(
            loading,
            play,
            loading.Finished);
    }
}

public class Menu : IState
{
    public void Tick()
    {
    }

    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }
}
public class Play : IState
{
    public void Tick()
    {
    }

    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }
}
public class LoadLevel : IState
{
    public bool Finished() => operations.TrueForAll(t => t.isDone);
    private List<AsyncOperation> operations = new List<AsyncOperation>();
    public void Tick()
    {
    }

    public void OnEnter()
    {
        operations.Add(SceneManager.LoadSceneAsync("MainLevel"));
        operations.Add(SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive));
        
    }

    public void OnExit()
    {
        operations.Clear();
    }
}
public class Pause : IState
{
    public void Tick()
    {
    }

    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }
}

