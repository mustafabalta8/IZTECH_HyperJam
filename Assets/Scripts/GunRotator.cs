using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotator : MonoBehaviour
{
    public bool isRotating = false;
    void Update()
    {
        if(isRotating)
        transform.Rotate(new Vector3(0, 90, 0));
    }
}
