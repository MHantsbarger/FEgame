﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera2D : MonoBehaviour {
     
     public float dampTime = 0.6f;
     public float dampDistance = 3.5f;
     private Vector3 velocity = Vector3.zero;
     public Transform target;
 
     // Update is called once per frame
     void FixedUpdate () 
     {
         if (target)
         {
             Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
             Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));

             if (delta.magnitude >= dampDistance) {
                 Vector3 destination = transform.position + delta;
                 transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
             }
         }
     
     }
 }
