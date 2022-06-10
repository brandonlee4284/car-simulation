using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Telemetry : MonoBehaviour
{
    [SerializeField] private bool activateTelemetry;
    [SerializeField] private GameObject TelemetryPanel;
    [SerializeField] private Text velocityBox;
    [SerializeField] private Text accelerationBox;
    [SerializeField] private Text x_CoordinateBox;
    [SerializeField] private Text y_CoordinateBox;
    [SerializeField] private Text z_CoordinateBox;
    private double lastVelocity;
    private int nextUpdateSpeed=1;

    // Start is called before the first frame update
    void Start()
    {
        activateTelemetry = true;
        lastVelocity = 0;
        accelerationBox.text = "Acceleration: 0 m/s^2";
      
    }

    // Update is called once per frame
    void Update()
    {
        if(activateTelemetry){
            TelemetryPanel.SetActive(true);
            velocityBox.text = "Velocity: " + getVelocity().ToString() + " m/s";
            x_CoordinateBox.text = "X: " + getXCoordinate().ToString() + " m";
            y_CoordinateBox.text = "Y: " + getYCoordinate().ToString() + " m";
            z_CoordinateBox.text = "Z: " + getZCoordinate().ToString() + " m";

        }else{
            TelemetryPanel.SetActive(false);
            velocityBox.text = "";
            x_CoordinateBox.text = "";
            y_CoordinateBox.text = "";
            z_CoordinateBox.text = "";
        }
    }

    void FixedUpdate(){
        if(activateTelemetry){
            accelerationBox.text = "Acceleration: " + getAcceleration().ToString() + " m/s^2";
            nextUpdateSpeed=Mathf.FloorToInt(Time.time)+1;
        }else{
            accelerationBox.text = "";
        }
    }

    public int getVelocity()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 velocityVector = rb.velocity;
        int velocity = (int) Math.Truncate(Math.Sqrt(Math.Pow(velocityVector.x,2) + Math.Pow(velocityVector.y,2) + Math.Pow(velocityVector.z,2)));
        return velocity;
    }

    int getXCoordinate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        int xCoord = (int) rb.position.x;
        return xCoord;
    }
    int getYCoordinate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        int yCoord = (int) rb.position.y;
        return yCoord;
    }
    int getZCoordinate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        int zCoord = (int) rb.position.z;
        return zCoord;
    }

    int getPosition()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 positionVector = rb.position;
        int position = (int) Math.Truncate(Math.Sqrt(Math.Pow(positionVector.x,2) + Math.Pow(positionVector.y,2) + Math.Pow(positionVector.z,2)));
        return position;
    }
    
    int getAcceleration()
    {
        //v = vo + at -> a = v-vo/t
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 velocityVector = rb.velocity;
        double velocity = Math.Sqrt(Math.Pow(velocityVector.x,2) + Math.Pow(velocityVector.y,2) + Math.Pow(velocityVector.z,2));
        int acceleration = (int) ((velocity - lastVelocity) / Time.fixedDeltaTime);
        lastVelocity = velocity;
        if(Math.Abs(acceleration) < 1 && Math.Abs(acceleration) > 0)
            acceleration = 0;
        return acceleration;
    }

    public void toggleTelemetry()
    {
        if(activateTelemetry){
            activateTelemetry = false;
        }else{
            activateTelemetry = true;
        }
    }
}
