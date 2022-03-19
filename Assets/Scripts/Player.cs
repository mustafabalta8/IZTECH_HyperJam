using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerMovement playerMovement;
    public static Animator characterAnimator;

    [SerializeField] BatarangController batarangController;
    [SerializeField] GameObject dart;
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        characterAnimator = gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Animator>();

        //characterAnimator.SetBool("isRunning", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WaitLine"))
        {
            Debug.Log("wait line");
            characterAnimator.SetBool("isRunning", false);
            playerMovement.Movement = Vector3.zero;
            Destroy(other.gameObject);
            PlayerMovement.instance.CanSideMove = false;
            SoundMananger.instance.PlayBeepSound();
        }
        if (other.CompareTag("Finish"))
        {
            playerMovement.Movement = Vector3.zero;
            characterAnimator.SetBool("isRunning", false);           
            PlayerMovement.instance.CanSideMove = false;

            //characterAnimator.SetBool("Throw", true);

            //batarangController.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            batarangController.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            batarangController.gameObject.transform.parent = null;
            batarangController.gunMesh.enabled = false;
            batarangController.gameObject.transform.position = new Vector3(gameObject.transform.position.x - 1.5f, gameObject.transform.position.x + 1, gameObject.transform.position.z + 1f);
            //BatarangController.finish = true;

            dart.SetActive(true);
        }
        /*
        if (other.gameObject.CompareTag("Bomb"))
        {
            characterAnimator.SetBool("isFalling", true);
            playerMovement.Movement = Vector3.zero;
            Destroy(other.gameObject);

        }*/
    }
    private void OnTriggerExit(Collider other)
    {
       
    }



}
