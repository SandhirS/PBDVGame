using System.Collections.Generic;
using UnityEngine;

public class Waypointmover : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float moveSpeed = 5f; 
    [SerializeField] private float distanceThreshold = 0.1f; 
    private int currentWaypointIndex = 0; 
    private int currentLap = 0; 
    private int maxLap = 3; 

    
    void Start()
    {
        if (waypoints == null || waypoints.Count == 0)
        {
            Debug.LogError("Please assign waypoints to the car.");
            return;
        }

        
        transform.position = waypoints[currentWaypointIndex].position;
        MoveToNextWaypoint();
    }

    
    void Update()
    {
        if (currentLap >= maxLap && currentWaypointIndex == 0) return;

        MoveTowardsWaypoint();
        CheckIfWaypointReached();
    }

    private void MoveTowardsWaypoint()
    {
        if (currentWaypointIndex < waypoints.Count)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);
        }
    }

    private void CheckIfWaypointReached()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < distanceThreshold)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Count)
            {
                currentWaypointIndex = 0;
                currentLap++;

                
                if (currentLap >= maxLap)
                {
                    Debug.Log("Completed all laps. Stopping at the first waypoint.");
                    return;
                }
            }

            MoveToNextWaypoint();
        }
    }

    private void MoveToNextWaypoint()
    {
        if (currentWaypointIndex < waypoints.Count)
        {
            transform.LookAt(waypoints[currentWaypointIndex]);
        }
    }
}