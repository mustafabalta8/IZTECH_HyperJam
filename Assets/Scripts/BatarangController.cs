using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatarangController : MonoBehaviour
{
    
    public static BatarangController instance;
    GunRotator gunRotator;
    public static bool finish;

    public Transform target;
    public float delay;

    public float speed;
    public float forceY;
    public float forceZ;

    private float time;

    public MeshRenderer gunMesh;
    void Start()
    {
        gunRotator = transform.GetChild(0).GetComponent<GunRotator>();
        Singelton();
        finish = false;
        time = 0.8f;
    }
    private void Singelton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (finish)
        {
            time -= Time.deltaTime;

            Debug.Log("Bitti");
            //playerMovement.Movement = Vector3.zero;
            //PlayerMovement.instance.CanSideMove = false;
            //Player.characterAnimator.SetBool("isRunning", false);
            Player.characterAnimator.SetBool("Throw", true);
            Debug.Log("bitti 22");
            if (time <= 0)
            {
                Debug.Log("time doldu");
                gunMesh.enabled = true;


                transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
                gunRotator.isRotating = true;
                //transform.LookAt(-target.position);
                //transform.Rotate(new Vector3(0, 90, 0));

                gameObject.transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
                /*
                delay -= Time.deltaTime;

                if(delay <= 0)
                {
                    Debug.Log("transparent objeler");
                    gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    delay = 0.35f;

                    if(gameObject.transform.GetChild(0).gameObject.activeSelf == true)
                        gameObject.transform.GetChild(1).gameObject.SetActive(true);

                    //finish = false;
                }*/

            }
            StartCoroutine(ThrowFinished());
        }
    }

    IEnumerator ThrowFinished()
    {
        yield return new WaitForSeconds(0.5f);
        Player.characterAnimator.SetBool("Throw", false);
        //
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Debug.Log("target destroyed");
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {           
            Destroy(gameObject);
        }
    }
}
