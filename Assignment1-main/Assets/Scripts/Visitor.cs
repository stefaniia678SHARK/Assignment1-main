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
    float waitTime = 5f;
    public FaceChange faceChange;

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
        StartCoroutine(ChangetheMood());
    }

    IEnumerator ChangetheMood()
    {
        if(agent.isStopped)
        {
            yield return new WaitForSeconds(waitTime);
            faceChange.SetAnnoyed();

            yield return new WaitForSeconds(5f);

            faceChange.SetAngry();
            agent.isStopped = false;
            //agent.SetDestination(assignedTable.exitPoint.position);
            Destroy(gameObject, 10f); //destroy visitor after 10 seconds of leaving


            //make if you broght bread the visitor becomes happy instead of angry
        }
    }

}
