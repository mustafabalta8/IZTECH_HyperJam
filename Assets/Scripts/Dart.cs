using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    private Vector3 dartMovement;

    [SerializeField] private Vector3 movement;
    void Update()
    {
        MoveDart();
    }

    private void MoveDart()
    {
        if (dartMovement.x < movement.x)
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
