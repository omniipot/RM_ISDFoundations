using System.Collections;
using System.Collections.Generic;


using UnityEngine;
// this is the movement engine for the player
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;
    public AudioClip[] footsteps;
    public AudioClip[] jumping;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;
    public AudioSource audioSource;
    public float walkStepInterval = 0.5f;
    public float runStepInterval = 0.3f;
    public float DefaultFov = 60f;

    public Vector3 horizontalVelocity;

    public float ActualSpeed;

    private float footstepTimer = 0f;

    public float zoomFactor = 1f;

    
    public bool canMove = true; 

    void Start()
    {
        canMove = true;
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    
    void Update()
    {
        
       
        Vector3 forward = transform.TransformDirection(Vector3.forward); 
        Vector3 right = transform.TransformDirection(Vector3.right);
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");


        bool IsMoving  = canMove && (Mathf.Abs(vertical) > 0.1f || Mathf.Abs(horizontal) > 0.1f);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0; 
        // if can move, use walkspeed, run speed if running, and set speed to the vertical axis for forward/backward, else set speed to 0
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        
       
        ActualSpeed = characterController.velocity.magnitude;
        
        


        if(IsMoving && canMove && characterController.isGrounded)
            { 
                footstepTimer -= Time.deltaTime; 
                if(footstepTimer <= 0f)
                {   
                    PlayFootstep();

                    footstepTimer = isRunning ? runStepInterval : walkStepInterval;   // changes footstep delay depending on run or walk speed
                    }
            }
        else
        {
            footstepTimer = 0f;
        }
                
      
         

    float currentSpeed = new Vector3(
        characterController.velocity.x,
        0f,
        characterController.velocity.z
        ).magnitude;

    float targetFov = DefaultFov + (currentSpeed * zoomFactor);

        playerCamera.fieldOfView = Mathf.Lerp(
        playerCamera.fieldOfView,
        targetFov,
        Time.deltaTime * 5f
        );
           

        if ((Input.GetButton("Jump") || Input.GetButton("Jump2")) && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
            PlayJump();
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftControl) && canMove)
        {
            characterController.height = crouchHeight;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;

        }
        else
        {
            characterController.height = defaultHeight;
            walkSpeed = 6f;
            runSpeed = 12f;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    void PlayFootstep()
    {
        if(footsteps.Length == 0)
            return;

        int index = Random.Range(0, footsteps.Length);

        audioSource.PlayOneShot(footsteps[index]);
    }
    
     void PlayJump()
    {
        if(jumping.Length == 0)
            return;

        int index = Random.Range(0, jumping.Length);

        audioSource.PlayOneShot(jumping[index]);
    }
}