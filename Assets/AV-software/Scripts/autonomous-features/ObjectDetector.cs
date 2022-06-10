/*
Assigns bounding boxes and labels to objects within the cameras frames
Uses these classifications to make certain actions
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField] private bool activateDetectionSystem;
    // Start is called before the first frame update
    void Start()
    {
        activateDetectionSystem = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleDetectionSystem()
    {
        if(activateDetectionSystem){
            activateDetectionSystem = false;
        }else{
            activateDetectionSystem = true;
        }
    }
}
