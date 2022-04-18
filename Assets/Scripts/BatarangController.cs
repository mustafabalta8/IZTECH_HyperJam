using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatarangController : MonoBehaviour
{  
    public static BatarangController instance;
    private GunRotator gunRotator;

    private static bool isThrowing;
    private bool throwSound;

    private Transform target;

    [SerializeField] private float delay;
    [SerializeField] private float speed;

    [SerializeField] private float waitingTimeBeforeThrowing = 0.8f;

    [SerializeField] private MeshRenderer gunMesh;

    public MeshRenderer GunMesh { get => gunMesh; set => gunMesh = value; }
    public static bool IsThrowing { get => isThrowing; set => isThrowing = value; }
    public Transform Target { get => target; set => target = value; }

    void Start()
    {
        Singelton();
        gunRotator = transform.GetChild(0).GetComponent<GunRotator>();
        
        IsThrowing = false;
        throwSound = false;       
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
        if (IsThrowing)
        {
            HandleThrowing();
        }
    }
    private void HandleThrowing()
    {
        waitingTimeBeforeThrowing -= Time.deltaTime;

        Player.CharacterAnimator.SetBool("Throw", true);
        if (waitingTimeBeforeThrowing <= 0)
        {
            if (!throwSound)
            {
                SoundMananger.instance.PlayThrowSound();
                throwSound = true;
            }
            GunMesh.enabled = true;

            transform.position = Vector3.MoveTowards(transform.position, Target.position, speed);
            gunRotator.IsRotating = true;

            gameObject.transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
        }

        StartCoroutine(EndThrowAnimation());
    }
    IEnumerator EndThrowAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        Player.CharacterAnimator.SetBool("Throw", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            FinishTheLevel();
        }
    }
    private void FinishTheLevel()
    {
        Player.CharacterAnimator.SetBool("Dance", true);
        UI_Manager.instance.OpenWinPanel();
        Destroy(gameObject);
    }

}
