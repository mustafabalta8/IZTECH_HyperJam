using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothSpeed = 0.125f;

    private void FixedUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smootedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);

        transform.position = smootedPos;
        //transform.LookAt(target);


    }
}
