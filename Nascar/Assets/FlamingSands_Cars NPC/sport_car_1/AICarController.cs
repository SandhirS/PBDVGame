using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarController : MonoBehaviour
{
    public Transform[] waypoints;
    public float maxSpeed = 200f;
    public float acceleration = 10f;
    public float turnSensitivity = 1f;

    private Rigidbody rb;
    private int currentWaypoint = 0;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        NavigateTowardsWaypoint();
    }

    void NavigateTowardsWaypoint()
    {
        if (waypoints.Length == 0) return;

        Vector3 targetPosition = waypoints[currentWaypoint].position;
        Vector3 direction = (targetPosition - transform.position).normalized;

        float moveInput = Mathf.Clamp01(Vector3.Dot(transform.forward, direction));
        float turnInput = Vector3.Cross(transform.forward, direction).y;

        ApplyWheelForces(moveInput, turnInput);

        if (Vector3.Distance(transform.position, targetPosition) < 5f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }

    void ApplyWheelForces(float moveInput, float turnInput)
    {
        float motorTorque = moveInput * acceleration;
        float steerAngle = turnInput * turnSensitivity;

        frontLeftWheelCollider.motorTorque = motorTorque;
        frontRightWheelCollider.motorTorque = motorTorque;

        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }
}
