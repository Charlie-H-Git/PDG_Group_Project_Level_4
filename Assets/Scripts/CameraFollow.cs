using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [Header("Camera Controls", order = 1)]public float smoothSpeed = 0.125f;
    public Vector3 offset; 
    
    [Header("================CAMERA CLAMPING SETTINGS==================", order = 2)]
    
    [Header("Camera Maximum Y Axis", order = 3)]public bool yMaxEnabled = false;
    public float yMaxValue = 0f;

    [Header("Camera Minimum Y Axis", order = 4)]public bool yMinEnabled = false;
    public float yMinValue = 0f;

    [Header("Camera Maximum Y Axis", order = 5)]public bool xMaxEnabled = false;
    public float xMaxValue = 0f;

    [Header("Camera Minimum x Axis", order = 6)]public bool xMinEnabled = false;
    public float xMinValue = 0f;
    
    private Vector3 desiredPosition;
    
    //LateUpdate is called every frame after all the Update functions have been called
    void LateUpdate()
    {
        //============================================SMOOTHED CAMERA FOLLOW======================================//
        //This smooths the camera movement using linear interpolation based off of player position against desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition + offset, smoothSpeed);
        // makes the camera use the smoothedPosition Vector
        transform.position = smoothedPosition;
    }

   

    
    void Update()

{    
    //=====================================CAMERA CLAMPING=====================================//
        
        Vector3 targetPos = target.position;
        //Vert defines the minimum and maximum value the camera can move on the Y axis 
        //If boolean conditions are met then enforce defined values on camera
        
       if (yMinEnabled && yMaxEnabled)
           //Restricts movement based on parameters and player position
            targetPos.y = Mathf.Clamp(target.position.y, yMinValue, yMaxValue);
        
        else if (yMinEnabled)
           //Restricts movement based on parameters and player position
            targetPos.y = Mathf.Clamp(target.position.y, yMinValue, target.position.y);
        
        else if (yMaxEnabled)
           //Restricts movement based on parameters and player position
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, yMaxValue);
        
        //Horiz defines the minimum and maximum value the camera can move between on the X axis
        //If boolean conditions are met then enforce defined values on camera
        if (xMinEnabled && xMaxEnabled)
            //Restricts movement based on parameters and player position
            targetPos.x = Mathf.Clamp(target.position.x, xMinValue, xMaxValue);
        
        else if (xMinEnabled)
            //Restricts movement based on parameters and player position
            targetPos.x = Mathf.Clamp(target.position.x,  xMaxValue, target.position.x);
        
        else if (xMaxEnabled)
            //Restricts movement based on parameters and player position
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, xMaxValue);
        //rewrite target position
        desiredPosition = targetPos;
    }
}