using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotator : MonoBehaviour
{
    private bool isRotating = false;

    public bool IsRotating { get => isRotating; set => isRotating = value; }

    void Update()
    {
        if(IsRotating)
        transform.Rotate(new Vector3(0, 90, 0));
    }
}
