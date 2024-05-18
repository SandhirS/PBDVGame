using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float maxSpeed = 200f;
    public float acceleration = 10f;
    public float turnSensitivity = 1f;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        Vector3 forwardMove = transform.forward * moveInput * acceleration;
        rb.AddForce(forwardMove, ForceMode.Acceleration);

        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(forwardMove, ForceMode.Acceleration);
        }

        Vector3 turn = transform.up * turnInput * turnSensitivity;
        rb.AddTorque(turn, ForceMode.VelocityChange);

        ApplyWheelForces(moveInput, turnInput);
    }

    void ApplyWheelForces(float moveInput, float turnInput)
    {
        frontLeftWheelCollider.motorTorque = moveInput * acceleration;
        frontRightWheelCollider.motorTorque = moveInput * acceleration;

        frontLeftWheelCollider.steerAngle = turnInput * turnSensitivity;
        frontRightWheelCollider.steerAngle = turnInput * turnSensitivity;
    }
}