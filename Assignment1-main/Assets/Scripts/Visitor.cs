using UnityEngine;
using UnityEngine.AI;

public class Visitor : MonoBehaviour
{

    public NavMeshAgent agent;
    public Table assignedTable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        agent.SetDestination(assignedTable.standPoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            StartWaiting();
        }
    }

    void StartWaiting()
    {
        // Logic for waiting at the table
    }
}
