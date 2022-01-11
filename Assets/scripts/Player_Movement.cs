using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Door Nils ten Pas
public class Player_Movement : MonoBehaviour
{

    public abstract class Command
    {
        public abstract void Execute();
    }

    public CharacterController characterController;
    public float speed = 3;
    public float sprint = 3;
    public float currentSpeed;
    private float groundedTimer;



    // camera and rotation
    public Transform cameraHolder;
    public float mouseSensitivity = 2f;
    public float upLimit = -50;
    public float downLimit = 50;

    public float jumpSpeed = 2;
    private Vector3 movingDirection = Vector3.zero;

    // gravity
    private float gravity = 9.81f;
    private float verticalSpeed = 0;

    void Update()
    {

        Jump();
        Rotate();
        Move();
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;           //Locked cursor aan het midden
        Cursor.visible = false;                             //De-activeert cursor
    }

    public void Rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);
        cameraHolder.Rotate(-verticalRotation * mouseSensitivity, 0, 0);

        Vector3 currentRotation = cameraHolder.localEulerAngles;
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
        cameraHolder.localRotation = Quaternion.Euler(currentRotation);
    }

    private void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            currentSpeed = speed + sprint;
        }
        else
        {
            currentSpeed = speed;
        }
        if (characterController.isGrounded == true && Input.GetKeyDown("space"))
        {
            movingDirection.y = jumpSpeed;
        }
        movingDirection.y -= gravity * Time.deltaTime;
        characterController.Move(movingDirection * Time.deltaTime);
    }

    private void Move()
    {
        if(Input.GetButton("Sprint"))
        {
            currentSpeed = speed + sprint;
        }
        else
        {
            currentSpeed = speed;
        }
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        if (characterController.isGrounded) verticalSpeed = -0.5f;      //zet dit van 0 naar -0.5f, nu drukt hij de character de grond in waardoor de is ground altij geupdate wordt
        else verticalSpeed -= gravity * Time.deltaTime;
        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);

        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
        characterController.Move(currentSpeed * Time.deltaTime * move + gravityMove * Time.deltaTime);
    }

   
}

