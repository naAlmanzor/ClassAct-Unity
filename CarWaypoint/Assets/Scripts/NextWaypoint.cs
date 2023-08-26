using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWaypoint : MonoBehaviour
{
    // Stores waypoints to be used
    [SerializeField] private Waypoints waypoints;

    // Speed
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;

    // Waypoint AI is moving to
    private Transform currentWaypoint;

    // Start is called before the first waypoint
    void Start()
    {
        // Initial Waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        // Next Waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        }
    }
}
