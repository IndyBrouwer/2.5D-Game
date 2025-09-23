using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputSystem_Actions inputActions;
    private Rigidbody playerRigidbody;
    private Animator animator;

    [Header("Movement Settings")]
    public float moveSpeed = 4f;
    private Vector2 moveInput; //In the Input System Action map, this is a Vector2 so needs to be here as well.

    [Header("Jump Settings")]
    public float jumpForce = 5f;

    private GroundCheck GroundCheckScript;
    private InteractableCheck InteractableCheckScript;


    private void Awake()
    {
        //Find rigidbody from player to move later
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        GroundCheckScript = GetComponent<GroundCheck>();
        InteractableCheckScript = GetComponent<InteractableCheck>();

        inputActions = new InputSystem_Actions();
    }

    private void Start()
    {
        playerRigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
        playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    private void FixedUpdate()
    {
        MovePlayer(moveInput);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void MovePlayer(Vector2 moveInput)
    {
        float xVelocity = moveInput.x * moveSpeed;

        Vector3 velocity = playerRigidbody.linearVelocity;
        velocity.x = xVelocity;
        playerRigidbody.linearVelocity = velocity;

        animator.SetFloat("xVelocity", Math.Abs(playerRigidbody.linearVelocity.x));
        animator.SetFloat("yVelocity", playerRigidbody.linearVelocity.y);

        //Rotate player to face movement direction (player rotated 90 degrees to face right on default)
        if (moveInput.x > 0.01f) //Moving right
        {
            transform.rotation = Quaternion.Euler(0, 90f, 0); //Face right
        }
        else if (moveInput.x < -0.01f) //Moving left
        {
            transform.rotation = Quaternion.Euler(0, -90f, 0); //Face left
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //Make player jump if grounded and jump button pressed
        if (context.performed && GroundCheckScript.isGrounded)
        {
            Vector3 velocity = playerRigidbody.linearVelocity;
            velocity.y = jumpForce;
            playerRigidbody.linearVelocity = velocity;
            GroundCheckScript.isGrounded = false;
            animator.SetTrigger("Jump");
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //If player is standing in front of a ladder, enable climbing function
            InteractableCheckScript.ClimbLadder();
        }
    }
}