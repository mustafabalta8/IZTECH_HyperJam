using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private bool isPlaying = false;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private Vector3 movement;    
    [SerializeField] private float swerveSpeed;
    [SerializeField] private Transform sideMovementRoot;
    [SerializeField] private float moveLimit;

    private float lastFrameFingerPositionX;
    private float moveFactorX;
    private bool canSideMove = true;

    public Vector3 Movement { 
        get { return movement; } 
        set { movement = value; } 
    }
    public bool CanSideMove
    {
        get { return canSideMove; }
        set { canSideMove = value; }
    }

    public static PlayerMovement instance;
    private void Awake()
    {
        Singelton();
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
    private void Update()
    {
        if (isPlaying)
        {
            MoveForward();
            if(canSideMove)
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
