using UnityEngine;
using UnityEngine.AI;

// This script provides a public interface
// for interacting with the NavMeshAgent component

[RequireComponent(typeof(NavMeshAgent))]
public class NavMover : MonoBehaviour
{
    NavMeshAgent agent;    

    // Awake() is called when the script instance is being loaded
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    //public getter/setter called Destination which will
    //return a private variable called destination with
    //get and will update the agent's destination and
    //start its movement with set.

    private Vector3 destination;
    public Vector3 Destination
    {
        get => destination;
        set
        {
            if (agent.isOnNavMesh) agent.destination = value;
            StartMove();
        }
    }
    public float Speed
    {
        get => agent.velocity.magnitude / agent.speed;
    }

    public bool DestinationReached(Vector3 position, float stopRange = 1f)
    {
        if (position == destination)
        {
            if (agent.remainingDistance <= stopRange) return true;
        }
        return false;
    }


    public void StartMove() 
    { 
        if (agent.isOnNavMesh) agent.isStopped = false; 
    }
    public void StopMove() 
    { 
        if (agent.isOnNavMesh) agent.isStopped = true; 
    }
}
