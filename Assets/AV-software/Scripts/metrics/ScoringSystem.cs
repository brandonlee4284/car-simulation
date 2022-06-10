/*
Calculates the score that user/agent recieves (use to calculate the loss)
Takes into account velocity, steering (handling), breaking, acceleration, following instructions (signs, edge cases, etc.)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoringSystem : MonoBehaviour
{
    [SerializeField] private Text scoreBox;
    private int score;
    private bool hasCollided;
    private bool hitCurb;

    private int nextUpdateSpeed=1;
    private double nextUpdateBuildingCollision=0.5;
    // Start is called before the first frame update
    void Start()
    {
        score = 100;
        hasCollided = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // iterate through checklist to determine new score
        if(Time.time>=nextUpdateSpeed){
            checkSpeed();
            nextUpdateSpeed=Mathf.FloorToInt(Time.time)+1;
        }
        if(Time.time>=nextUpdateBuildingCollision){
            checkObjectCollision();
            nextUpdateBuildingCollision=Mathf.FloorToInt(Time.time)+0.5;
        }


        scoreBox.text = "Score: " + score.ToString() + "/100";
    }

    void checkSpeed()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 velocityVector = rb.velocity;
        double velocity = Math.Sqrt(Math.Pow(velocityVector.x,2) + Math.Pow(velocityVector.y,2) + Math.Pow(velocityVector.z,2));
        
        if(velocity > 20){
            score--;
        }
    }

    void checkObjectCollision()
    {
        if(hasCollided){
            score--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        hasCollided = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        hasCollided = false;
    }
}
