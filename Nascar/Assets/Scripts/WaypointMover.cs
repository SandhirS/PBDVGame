using System.Collections.Generic;
using UnityEngine;

public class Waypointmover : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints; // List of waypoints
    [SerializeField] private float moveSpeed = 5f; // Speed of the car
    [SerializeField] private float distanceThreshold = 0.1f; // Distance threshold to consider waypoint reached

    private int currentWaypointIndex = 0; // Index of the current waypoint
    private int currentLap = 0; // Current lap
    private int maxLap = 3; // Total number of laps

    // Start is called before the first frame update
    void Start()
    {
        if (waypoints == null || waypoints.Count == 0)
        {
            Debug.LogError("Please assign waypoints to the car.");
            return;
        }

        // Set the car's initial position to the first waypoint
        transform.position = waypoints[currentWaypointIndex].position;
        MoveToNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLap >= maxLap && currentWaypointIndex == 0) return; // Stop moving after completing the specified number of laps

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

                // Only stop if the lap count reaches maxLap and we are at the first waypoint
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