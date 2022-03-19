using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    Vector3 dartMovement;

    [SerializeField] Vector3 movement;
    //[SerializeField] Vector3 verticalMovement;
    void Update()
    {
        if ( dartMovement.x < movement.x)
        {
            dartMovement += Vector3.right * Time.deltaTime;
        }
        
        if (dartMovement.y < movement.y)
        {
            dartMovement += Vector3.up * Time.deltaTime;
        }
        transform.position += transform.position + dartMovement;
    }
}
