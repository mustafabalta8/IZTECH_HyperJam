using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private static Animator characterAnimator;

    [SerializeField] private BatarangController batarangController;
    [SerializeField] private GameObject dart;

    public static Animator CharacterAnimator { get => characterAnimator; set => characterAnimator = value; }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        CharacterAnimator = gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WaitLine"))
        {
            TriggerWaitingInForntOfSceen(other);
        }
        if (other.CompareTag("Finish"))
        {
            StartDartGame();
        }
        if (other.CompareTag("Bomb"))
        {
            CollideWithBomb(other);
        }
    }

    private void StartDartGame()
    {
        playerMovement.Movement = Vector3.zero;
        CharacterAnimator.SetBool("isRunning", false);
        PlayerMovement.instance.CanSideMove = false;

        batarangController.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        batarangController.gameObject.transform.parent = null;
        batarangController.GunMesh.enabled = false;
        batarangController.gameObject.transform.position = new Vector3(gameObject.transform.position.x - 1.5f, gameObject.transform.position.x + 1, gameObject.transform.position.z + 1f);

        dart.SetActive(true);
    }

    private void TriggerWaitingInForntOfSceen(Collider other)
    {
        CharacterAnimator.SetBool("isRunning", false);
        playerMovement.Movement = Vector3.zero;
        Destroy(other.gameObject);
        PlayerMovement.instance.CanSideMove = false;
        SoundMananger.instance.PlayBeepSound();
    }

    private void CollideWithBomb(Collider other)
    {
        playerMovement.Movement = Vector3.zero;
        CharacterAnimator.SetBool("isRunning", false);
        CharacterAnimator.SetBool("Faled", true);
        Camera.FindObjectOfType<Animator>().SetBool("Bomb", true);
        PlayerMovement.instance.CanSideMove = false;
        Destroy(other.gameObject);

        StartCoroutine(ResumeGame(2f));
    }

    IEnumerator ResumeGame(float time)
    {
        yield return new WaitForSeconds(time);

        playerMovement.Movement = Vector3.forward;
        CharacterAnimator.SetBool("Faled", false);
        CharacterAnimator.SetBool("isRunning", true);
        PlayerMovement.instance.CanSideMove = true;
    }



}
