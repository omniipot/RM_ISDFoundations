using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // Init Variables
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

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;
    // I chose a character controller because its less frustrating than a rigidbody for a first person controller. 
    private bool canMove = true;

    void Start()
    { // locks cursor so you can't see it and it doesn't leave the game window when playing.
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // sprint check, if the player is holding down left shift, they will run instead of walk.
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        // if can move is true, player can move, if they are running, use run speed, if not, use walk speed. If canMove is false, set speed to 0.
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        // adds both vertical and horizontal movement to the moveDirection vector, which is then used to move the player.

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
            // if the player is grounded and presses the jump button, set the y value of moveDirection to jumpPower, which will make the player jump.
        }
        else
        {
            moveDirection.y = movementDirectionY;
            // else character is not grounded, so they can't jump
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
            // while character is not grounded, apply gravity to value of moveDirection.y, which will make the player fall.
        }

        if (Input.GetKey(KeyCode.LeftControl) && canMove)
        {
            characterController.height = crouchHeight;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;
            // if left control is held down, set controller height to crouchHeight, and set walk and run speed to crouchspeed equivalent

        }
        else
        {
            characterController.height = defaultHeight;
            walkSpeed = 6f;
            runSpeed = 12f;
            // reset controller height to defaultHeight, and reset walk and run speed to their original values.
        }

        characterController.Move(moveDirection * Time.deltaTime);
        // ensures movement is independent of framerate.

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            // if canMove is true, allow the player to look around with the mouse. The rotationX variable is used to limit how far the player can look up and down, while the transform.rotation is used to rotate the player left and right.
        }
    }
}