using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private bool isPlaying = false;
    [SerializeField] private float speed;

    [SerializeField] public Vector3 movement;

    //public Vector3 Movement { set {  } get { return movement; } }


    [SerializeField] private float swerveSpeed;
    [SerializeField] private Transform sideMovementRoot;
    [SerializeField] private float moveLimit;

    private float lastFrameFingerPositionX;
    private float moveFactorX;

    public static PlayerMovement instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        }
        if (isPlaying)
        {
            MoveForward();
            HandleSideMovement();
        }

    }



    private void MoveForward()
    {
        transform.Translate(movement * Time.deltaTime * speed);
    }
    private void HandleSideMovement()
    {
        //float sideMovement = Input.GetAxisRaw("Horizontal");
        //transform.Translate(new Vector3(0,-sideMovement,0) * speed * Time.deltaTime );
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }


        float swerveAmount = swerveSpeed * moveFactorX;
        var currentPos = this.sideMovementRoot.localPosition;
        currentPos.x += swerveAmount;
        currentPos.x = Mathf.Clamp(currentPos.x, -moveLimit, moveLimit);
        this.sideMovementRoot.localPosition = currentPos;
    }
}
