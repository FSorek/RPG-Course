using System;
using UnityEngine;
using UnityEngine.AI;

public class EntityStateMachine : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent navMeshAgent;

    public Type CurrentStateType => stateMachine.CurrentState.GetType();

    private void Awake()
    {
        var player = FindObjectOfType<Player>();
        stateMachine = new StateMachine();
        navMeshAgent = GetComponent<NavMeshAgent>();
        
        var idle = new Idle();
        var chasePlayer = new ChasePlayer(navMeshAgent);
        var attack = new Attack();
        
        stateMachine.Add(idle);
        stateMachine.Add(chasePlayer);
        stateMachine.Add(attack);
        
        stateMachine.AddTransition(
            idle, 
            chasePlayer, 
            () => DistanceFlat(navMeshAgent.transform.position, player.transform.position) < 5f);
        stateMachine.AddTransition(
            chasePlayer, 
            attack, 
            () => DistanceFlat(navMeshAgent.transform.position, player.transform.position) < 2f);
        
        stateMachine.SetState(idle);
    }

    private float DistanceFlat(Vector3 source, Vector3 destination)
    {
        return Vector3.Distance(new Vector3(source.x, 0, source.z), new Vector3(destination.x, 0, destination.z));
    }
    private void Update()
    {
        stateMachine.Tick();
    }
}