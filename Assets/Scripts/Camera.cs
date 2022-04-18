using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed = 0.125f;

    private void LateUpdate()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smootedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smootedPos;
    }
}
