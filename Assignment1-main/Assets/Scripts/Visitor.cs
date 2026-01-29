using System.Runtime.CompilerServices;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI; //using smart way to walk - automatically will calculate
                      //where visitor can walk and what obsticles neede to be passed


public class Visitor : MonoBehaviour
{

    public NavMeshAgent agent; //for calculating the path to walk from current position
                               //to target position

    public Table assignedTable;
    public FaceChange faceChange;

    public float waitTime = 5f;
    public float eatTime = 10f;

    bool isWatiting = false;
    bool isEating = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        agent.SetDestination(assignedTable.standPoint.position);
        faceChange.SetHappy();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWatiting && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            StartCoroutine(WaitingForBread());
            isWatiting = true;
        }
    }

    IEnumerator WaitingForBread()
    {
        yield return new WaitForSeconds(waitTime);
        
        if (assignedTable.hasBread)
        {
            yield break;
        }

        faceChange.SetAnnoyed();

        yield return new WaitForSeconds(5f); 
        agent.isStopped = false;

        if (assignedTable.hasBread)
        {
            yield break;
            faceChange.SetHappy();
            Leave();
        }

        faceChange.SetAngry();
        Leave();

        Debug.Log("Visitor is leaving due to no bread");

    }

    public void OnBreadPlaced()
    {
        if (isEating)
        {
            return;
        }

        StartCoroutine(EatBread());
    }

    IEnumerator EatBread()
    {
        isEating = true;
        faceChange.SetHappy();

        yield return new WaitForSeconds(eatTime);

        GiveMoney();
        Leave();
    }

    void GiveMoney()
    {
        //
    }

    void Leave()
    {
        assignedTable.isOccupied = false;
        agent.isStopped = false;
        agent.SetDestination(assignedTable.exitPoint.position);
        Destroy(gameObject, 10f);

        Debug.Log("is Occuupied ??? " + assignedTable.isOccupied);
    }


}
