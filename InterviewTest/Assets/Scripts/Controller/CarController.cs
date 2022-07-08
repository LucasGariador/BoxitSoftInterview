using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(GetInput))]
public class CarController : MonoBehaviour
{
    [SerializeField] private float carSpeed;
    [SerializeField] private float carBreakeForce;
    [SerializeField] private float maxCarSpeed;
    [SerializeField] private float maxSteerAngle;

    private float currentSteerAngle;
    private float currentBrakeForce;

    private Rigidbody rb;
    private GetInput _input;

    [SerializeField] private WheelCollider wheelColliderBL;
    [SerializeField] private WheelCollider wheelColliderBR;
    [SerializeField] private WheelCollider wheelColliderFL;
    [SerializeField] private WheelCollider wheelColliderFR;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _input = GetComponent<GetInput>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleBrake();
        HandleSteering();

        ShowStats.speed = rb.velocity.magnitude * 10;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * _input.direction;
        wheelColliderFL.steerAngle = currentSteerAngle;
        wheelColliderFR.steerAngle = currentSteerAngle;
    }

    private void HandleBrake()
    {
        currentBrakeForce = _input.IsBraking ? carBreakeForce : 0;

        wheelColliderBL.brakeTorque = currentBrakeForce;
        wheelColliderBR.brakeTorque = currentBrakeForce;
        wheelColliderFL.brakeTorque = currentBrakeForce;
        wheelColliderFR.brakeTorque = currentBrakeForce;
    }

    private void HandleMovement()
    {
        int vMove = _input.IsForward ? 1 : -1;
        if (_input.IsRunning) 
        {
            wheelColliderFL.motorTorque = vMove * carSpeed;
            wheelColliderFR.motorTorque = vMove * carSpeed;
        }


        //
        if(rb.velocity.magnitude >= maxCarSpeed)
        {
            currentBrakeForce = carBreakeForce;
        }
        //
        if(rb.velocity.magnitude < 0.5 && !_input.IsRunning)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
