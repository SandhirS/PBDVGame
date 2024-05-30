using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private EnemyAIWaypoint waypoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold=0.1f;
    private Transform currentWaypoint;

    public int max_lap = 3;
    public int curr_lap = 0;
    public Transform waypoint_checker;

    // Start is called before the first frame update
    void Start()
    {
        
        currentWaypoint=waypoints.GetNextWaypoint(currentWaypoint);
        transform.position=currentWaypoint.position;
        

        currentWaypoint=waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
     
    }

    // Update is called once per frame
    void Update()
    {
        if (curr_lap >= max_lap) return; // Stop moving after completing 3 loops

        MoveTowardsWaypoint();
        CheckIfWaypointReached();
    }

     

     private void MoveTowardsWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
    }

     private void CheckIfWaypointReached()
    {
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            if (currentWaypoint == null)
            {
                curr_lap++;
                if (curr_lap < max_lap)
                {
                    Start(); // Restart waypoints
                }
                else
                {
                    // Optionally handle what to do when maxLoops is reached
                    Debug.Log("Completed all loops.");
                }
            }
            else
            {
                transform.LookAt(currentWaypoint);
            }
        }
    }






    
}
