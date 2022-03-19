using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public void SendPosition()
    {
        Debug.Log("target: "+transform.position);
        BatarangController.instance.target = transform;
        BatarangController.finish = true;
    }
}
