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

    public GameObject money;

    public Table assignedTable;
    public FaceChange faceChange;

    public float waitTime = 5f;
    public float eatTime = 10f;

    bool isWaiting = false;
    bool isEating = false;
    bool isLeaving = false;


    public Transform moneySpawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        agent.SetDestination(assignedTable.standPoint.position);
        faceChange.SetHappy();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaiting && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            StartCoroutine(WaitingForBread());
            isWaiting = true;
        }
    }

    IEnumerator WaitingForBread()
    {
        yield return new WaitForSeconds(waitTime);
        
        if (assignedTable.hasBread)
        {
            StartCoroutine(EatBread());
            yield break;
        }

        faceChange.SetAnnoyed();

        yield return new WaitForSeconds(5f); 
        agent.isStopped = false;

        if (assignedTable.hasBread && !isEating)
        {
            StartCoroutine(EatBread());
            faceChange.SetHappy();
            yield break;
        }

        faceChange.SetAngry();

          Leave();

        Debug.Log("Visitor is leaving due to no bread");

    }

    //seeing which visitor is currrent to that table
    public void OnBreadPlaced()
    {
        if (isEating || isLeaving)
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

    //When visitor gets bread this function will be called after 10 seconds and spawn money
    void GiveMoney()
    {
        Instantiate(money, moneySpawnPoint.position, moneySpawnPoint.rotation);
    }

    //visitor leaves the restaurant
    void Leave()
    {
        if (isLeaving)
        {
            return;
        }

        isLeaving = true;

        assignedTable.ClearTable(); //calling function from table script - just reseting values
                                    //so visitors will know this table if free now

        isWaiting = false;
        isEating = false;

        agent.isStopped = false;
        agent.SetDestination(assignedTable.exitPoint.position);
        Destroy(gameObject, 10f);

        Debug.Log("is Occuupied ??? " + assignedTable.isOccupied);
    }


}
