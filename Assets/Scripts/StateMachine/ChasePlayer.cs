using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.AI;

public class ChasePlayer : IState
{
    private readonly NavMeshAgent agent;
    private readonly Player player;

    public ChasePlayer(NavMeshAgent agent, Player player)
    {
        this.agent = agent;
        this.player = player;
    }
    public void Tick()
    {
        agent.SetDestination(player.transform.position);
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