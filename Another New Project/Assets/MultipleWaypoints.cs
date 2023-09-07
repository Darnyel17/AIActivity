using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MultipleWaypoints : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform targetWaypoint;
    public List<Transform> wayPoints;
    public int wayPointNumber;
    public bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        foreach (Transform t in targetWaypoint.GetComponentInChildren<Transform>())
        {
            wayPoints.Add(t.gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    MovetoRandomWayPoint();
                }
            }
        }
    }

    void MovetoRandomWayPoint()
    {
        if (wayPoints.Count == 0)
        {
            Debug.LogError("No Waypoints");
            return;
        }

        isMoving = true;
        int newWaypointIndex = GetRandomWaypointIndex();

        if (newWaypointIndex != wayPointNumber) 
        { 
            wayPointNumber = newWaypointIndex;
            agent.SetDestination(wayPoints[wayPointNumber].position);
        }
    }

    private int GetRandomWaypointIndex()
    {
        return Random.Range(0, wayPoints.Count);
    }
}
