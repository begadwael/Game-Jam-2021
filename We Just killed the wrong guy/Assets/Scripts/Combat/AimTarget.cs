using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AimTarget : MonoBehaviour
{
    [SerializeField] Transform cam;
    Ray ray;
    RaycastHit hitInfo;
    
    void Start()
    {
    }
    void Update()
    {
        ray.origin=cam.transform.position;
        ray.direction=cam.transform.forward;
       if( Physics.Raycast(ray,out hitInfo)){
        transform.position=hitInfo.point;}
        else{
            transform.position=cam.transform.forward*20f+cam.transform.position;
        }
    }
}   
