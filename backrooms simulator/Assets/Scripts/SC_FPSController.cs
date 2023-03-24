using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public static float lookSpeed;
    public Camera playerCamera;
    public float lookXLimit = 45.0f;
    public float timer = 0;
    public float bob = 2;
    bool isRunning = false;
    AudioSource aud;

    float timer2 = 0;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        if (lookSpeed == 0)
        { lookSpeed = 2.0f; }
        aud = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
        StartCoroutine(runCooldown());
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = 0, curSpeedY = 0;
        if (canMove)
        {
            if (isRunning)
            {
                curSpeedX = runningSpeed * Input.GetAxis("Vertical");
                curSpeedY = runningSpeed * Input.GetAxis("Horizontal");
            }
            else
            {
                curSpeedX = walkingSpeed * Input.GetAxis("Vertical");
                curSpeedY = walkingSpeed * Input.GetAxis("Horizontal");
            }
        }
        //float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        //float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            timer += Time.deltaTime;
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX +
                (Mathf.Sin(timer) * bob), 0, 0);
            // timer += Time.deltaTime * walkingBobbingSpeed;
            //transform.localPosition = new Vector3
            //(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) 
            //* bobbingAmount, transform.localPosition.z);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        else { timer = 0; }
    }
    IEnumerator runCooldown()
    {
        //while running
        while(true)
        {
            yield return new WaitForSeconds(0.2f);
            if (isRunning)
            {
                //add to a timer
                timer2++;
                
                if (timer2 == 20)
                {
                    //reassign speeds

                    walkingSpeed = 5;
                    runningSpeed = walkingSpeed;
                    aud.Play();
                    //start a cooldown refresh
                    yield return new WaitForSeconds(3f);
                    aud.Stop();
                    timer2 = 0;
                    walkingSpeed = 7;
                    runningSpeed = 11;
                }

                
            }
            else
            {
                if (timer2 > 0)
                    timer2--;
            }
        }

    }
      
    
}