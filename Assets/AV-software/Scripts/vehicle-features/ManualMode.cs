/*
Manually Controls Vehicle (for testing purposes/collect data)
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualMode : MonoBehaviour
{
    [SerializeField] private bool activateManualMode;
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    [SerializeField] private Camera frontCenterCamera;
    [SerializeField] private Camera rearCenterCamera;
    [SerializeField] private Camera rightCenterCamera;
    [SerializeField] private Camera leftCenterCamera;
    [SerializeField] private Camera frontLeftCamera;
    [SerializeField] private Camera frontRightCamera;
    [SerializeField] private Camera rearLeftCamera;
    [SerializeField] private Camera rearRightCamera;
    [SerializeField] private Camera mainCamera;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    // constructor
    private void Start(){
        activateManualMode = false;
        frontCenterCamera.enabled = false;
        rearCenterCamera.enabled = false;
        rightCenterCamera.enabled = false;
        leftCenterCamera.enabled = false;
        frontLeftCamera.enabled = false;
        frontRightCamera.enabled = false;
        rearLeftCamera.enabled = false;
        rearRightCamera.enabled = false;
        
    }

    private void Update(){
        
        


    }

    // can miss frames if monitor is too slow
    private void FixedUpdate()
    {
        
        if(activateManualMode){
            GetInput();
            HandleMotor();
            HandleSteering();
            UpdateWheels();
        }
        

    }

    public void toggleManualMode()
    {
        if(activateManualMode){
            activateManualMode = false;
        }else
        {
            activateManualMode = true;
        }
    }


    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();       
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;       
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
    

}