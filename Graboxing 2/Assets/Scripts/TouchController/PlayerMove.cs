using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public FixedJoystick joystick;
    public static float moveSpeed = 2f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;

    [SerializeField] private string sceneToLoad;
    public static string m_SceneToLoad;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        m_SceneToLoad = sceneToLoad;
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance);

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

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("SceneChanger"))
        {
            SceneManager.LoadScene(m_SceneToLoad);
        }
    }
}
