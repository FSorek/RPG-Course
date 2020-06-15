using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private void Awake()
    {
        panel.SetActive(false);
        GameStateMachine.OnGameStateChanged += HandleGameStateChanged;
    }

    private void OnDestroy()
    {
        GameStateMachine.OnGameStateChanged -= HandleGameStateChanged;
    }

    private void HandleGameStateChanged(IState state)
    {
        panel.SetActive(state is Pause);
    }
}
