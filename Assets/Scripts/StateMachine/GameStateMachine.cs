using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateMachine : MonoBehaviour
{
    public static event Action<IState> OnGameStateChanged = delegate {  };
    private static bool initialized;
    
    private StateMachine stateMachine;
    public Type CurrentStateType => stateMachine.CurrentState.GetType();

    private void Awake()
    {
        if (initialized)
        {
            Destroy(gameObject);
            return;
        }

        initialized = true;
        DontDestroyOnLoad(gameObject);
        
        stateMachine = new StateMachine();
        stateMachine.OnStateChanged += state => OnGameStateChanged(state);
        
        var menu = new Menu();
        var loading = new LoadLevel();
        var play = new Play();
        var pause = new Pause();
        
        stateMachine.SetState(menu);
        
        stateMachine.AddTransition(
            menu, 
            loading,
            () => PlayButton.LevelToLoad != null);
        stateMachine.AddTransition(
            loading,
            play,
            loading.Finished);
        stateMachine.AddTransition(
            play,
            pause,
            () => Input.GetKeyDown(KeyCode.Escape));
        stateMachine.AddTransition(
            pause,
            play,
            () => Input.GetKeyDown(KeyCode.Escape));
        stateMachine.AddTransition(
            pause,
            menu,
            () => RestartButton.Pressed);
    }

    private void Update()
    {
        stateMachine.Tick();
    }
}

public class Menu : IState
{
    public void Tick()
    {
    }

    public void OnEnter()
    {
        PlayButton.LevelToLoad = null;
        SceneManager.LoadSceneAsync("Menu");
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
        operations.Add(SceneManager.LoadSceneAsync(PlayButton.LevelToLoad));
        operations.Add(SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive));
        
    }

    public void OnExit()
    {
        operations.Clear();
    }
}
public class Pause : IState
{
    public static bool Active { get; private set; }
    public void Tick()
    {
    }

    public void OnEnter()
    {
        Active = true;
        Time.timeScale = 0;
    }

    public void OnExit()
    {
        Active = false;
        Time.timeScale = 1;
    }
}

