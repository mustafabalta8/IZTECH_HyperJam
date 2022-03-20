using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown: " + transform.position);
        Debug.Log("name: " + gameObject.name);
        BatarangController.instance.target = transform;
        BatarangController.finish = true;
    }
}
