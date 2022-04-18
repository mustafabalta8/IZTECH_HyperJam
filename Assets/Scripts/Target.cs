using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnMouseDown()
    {
        StartThrowingBatarang();
    }

    private void StartThrowingBatarang()
    {
        //Debug.Log("OnMouseDown: " + transform.position);
        //Debug.Log("name: " + gameObject.name);
        BatarangController.instance.Target = transform;
        BatarangController.IsThrowing = true;
    }
}
