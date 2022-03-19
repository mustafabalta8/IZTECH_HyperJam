using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerMovement playerMovement;
    public static Animator characterAnimator;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        //characterAnimator = gameObject.GetComponent<Animator>();
        characterAnimator = gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Animator>();

        characterAnimator.SetBool("isRunning", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WaitLine"))
        {
            characterAnimator.SetBool("isRunning", false);
            playerMovement.Movement = Vector3.zero;
            Destroy(other.gameObject);
            PlayerMovement.instance.CanSideMove = false;
        }
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Bitti");
            playerMovement.Movement = Vector3.zero;
            PlayerMovement.instance.CanSideMove = false;
            characterAnimator.SetBool("isRunning", false);
            characterAnimator.SetBool("Throw", true);

            FindObjectOfType<BatarangController>().gameObject.GetComponent<Rigidbody>().isKinematic = false;
            FindObjectOfType<BatarangController>().gameObject.GetComponent<BoxCollider>().isTrigger = false;
            FindObjectOfType<BatarangController>().gameObject.transform.parent = null;
            FindObjectOfType<BatarangController>().gameObject.GetComponent<MeshRenderer>().enabled = false;
            FindObjectOfType<BatarangController>().gameObject.transform.position = new Vector3(gameObject.transform.position.x - 1.5f, gameObject.transform.position.x + 1, gameObject.transform.position.z + 1f);
            BatarangController.finish = true;
            StartCoroutine(ThrowFinished());
        }
    }

    IEnumerator ThrowFinished()
    {
        yield return new WaitForSeconds(0.5f);
        characterAnimator.SetBool("Throw", false);
    }
}
