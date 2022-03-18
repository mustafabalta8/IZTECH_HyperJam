using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WaitLine"))
        {
            Debug.Log("trigger worked");
            playerMovement.movement = Vector3.zero;
            Destroy(other.gameObject);
        }
    }
}
