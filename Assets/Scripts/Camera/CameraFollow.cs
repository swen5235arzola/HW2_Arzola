using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Unity Tutorial
//Modified By: Adriana Arzola
//Date: 04/06/19
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPostion = target.position + offset;
        transform.position = Vector3.Lerp(
                                        transform.position, 
                                        targetCamPostion, 
                                        smoothing * Time.deltaTime);
    }
}
