using System;
using UnityEngine;
using UnityEngine.AI;

public class EntityStateMachine : MonoBehaviour
{
    public event Action<IState> OnEntityStateChanged = delegate {  };
    
    private StateMachine stateMachine;
    private NavMeshAgent navMeshAgent;
    private Entity entity;

    public Type CurrentStateType => stateMachine.CurrentState.GetType();

    private void Awake()
    {
        var player = FindObjectOfType<Player>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        entity = GetComponent<Entity>();
        stateMachine = new StateMachine();

        stateMachine.OnStateChanged += state => OnEntityStateChanged(state);
        
        var idle = new Idle();
        var chasePlayer = new ChasePlayer(navMeshAgent, player);
        var attack = new Attack();
        var dead = new Dead(entity);

        stateMachine.AddTransition(
            idle, 
            chasePlayer, 
            () => DistanceFlat(navMeshAgent.transform.position, player.transform.position) < 5f);
        stateMachine.AddTransition(
            chasePlayer, 
            attack, 
            () => DistanceFlat(navMeshAgent.transform.position, player.transform.position) < 2f);
        
        stateMachine.AddAnyTransition(dead, () => entity.Health <= 0);
        
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