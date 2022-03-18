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
            
            playerMovement.Movement = Vector3.zero;
            Destroy(other.gameObject);
            PlayerMovement.instance.CanSideMove = false;
        }
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Bitti");
        }
    }
}
