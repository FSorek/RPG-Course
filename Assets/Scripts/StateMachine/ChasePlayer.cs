using UnityEngine.AI;

public class ChasePlayer : IState
{
    private readonly NavMeshAgent agent;

    public ChasePlayer(NavMeshAgent agent)
    {
        this.agent = agent;
    }
    public void Tick()
    {
        
    }

    public void OnEnter()
    {
        agent.enabled = true;
    }

    public void OnExit()
    {
        agent.enabled = false;
    }
}