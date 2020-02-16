﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public static CameraFollower sharedInstance;

    public GameObject followTarget;
    private Vector3 offset;

    public float movementSmoothness = 1.0f;
    public float rotationSmoothness = 1.0f;

    public bool canFollow = true;

    private void Start()
    {       
        offset = transform.position - followTarget.transform.position;
    }
    /*private void Awake()
    {
        sharedInstance = this;
    }*/

    private void LateUpdate()
    {
        if(followTarget == null || canFollow == false)
        {
            return;
        }
        
        transform.position = followTarget.transform.position + offset;
        
        /*transform.position = Vector3.Lerp(transform.position, followTarget.transform.position,
                                           Time.deltaTime * movementSmoothness);
        transform.rotation = Quaternion.Slerp(transform.rotation, followTarget.transform.rotation,
                                            Time.deltaTime * rotationSmoothness);*/
    }
}
