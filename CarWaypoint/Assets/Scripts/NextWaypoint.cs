using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWaypoint : MonoBehaviour
{
    // Stores waypoints to be used
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private CarAI carAI;

    //Rotation Speed

    [Range(0f, 15f)]
    [SerializeField] private float rotateSpeed = 10f;


    [SerializeField] private float distanceThreshold = 0.1f;

    // Waypoint AI is moving to
    private Transform currentWaypoint;

    // Rotation for current frame
    private Quaternion rotationGoal;

    // Direction of waypoint rotation
    private Vector3 directionToWaypoint;

    // Start is called before the first waypoint
    void Start()
    {
        // Initial Waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        
        // Sets Initial position as starting waypoint
        // transform.position = currentWaypoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, carAI.carSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            // transform.LookAt(currentWaypoint);
        }

        RotateToWaypoint();
    }

    private void RotateToWaypoint()
    {
        directionToWaypoint = (currentWaypoint.position - transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(directionToWaypoint);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }
}
