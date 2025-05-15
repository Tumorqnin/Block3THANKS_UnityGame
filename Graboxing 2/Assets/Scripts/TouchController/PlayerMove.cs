using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public FixedJoystick joystick;
    public static float moveSpeed = 2f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // small downward force to keep grounded
        }

        // Get joystick input
        Vector3 move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    // Optional: Add a jump method later if needed
}
