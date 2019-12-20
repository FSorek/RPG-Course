using System;
using UnityEngine;
using UnityEngine.AI;

public class EntityStateMachine : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        stateMachine = new StateMachine();
        navMeshAgent = GetComponent<NavMeshAgent>();
        
        var idle = new Idle();
        var chasePlayer = new ChasePlayer(navMeshAgent);
        var attack = new Attack();
        
        stateMachine.Add(idle);
        stateMachine.Add(chasePlayer);
        stateMachine.Add(attack);
        
        stateMachine.SetState(idle);
    }

    private void Update()
    {
        stateMachine.Tick();
    }
}