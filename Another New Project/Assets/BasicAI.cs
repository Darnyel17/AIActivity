using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BasicAI : MonoBehaviour
{
    public Transform waypointA, waypointB;
    public Transform targetWaypoint;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(targetWaypoint == null)
        {
            Debug.LogError("No Target Waypoint");
        }
        else
        {
            SetDestination(waypointA);
        }
    }

    private void SetDestination(Transform destination)
    {
        if(agent != null) 
        { 
            targetWaypoint = destination;
            agent.SetDestination(destination.position);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if(targetWaypoint.hasChanged)
        //{
        //    agent.SetDestination(targetWaypoint.position);
        //    targetWaypoint.hasChanged = false;
        //}

        if (targetWaypoint != waypointA && targetWaypoint != waypointB)
        {
            return;
        }
        if (agent.remainingDistance < .1f)
        {
            if(targetWaypoint == waypointA) 
            {
                SetDestination(waypointB);
            }
            else
            {
                SetDestination(waypointA);
            }
        }
    }
}

