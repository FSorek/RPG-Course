using UnityEngine;
using UnityEngine.AI;

public class NavmeshMover : IMover
{
    private readonly Player player;
    private NavMeshAgent navmeshAgent;

    public NavmeshMover(Player player)
    {
        this.player = player;
        navmeshAgent = player.GetComponent<NavMeshAgent>();
        navmeshAgent.enabled = true;
    }
    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo))
            {
                navmeshAgent.SetDestination(hitInfo.point);
            }
        }
    }
}