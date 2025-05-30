using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    //keep track if the screen is being pressed on either side
    int rightFingerId;
    int leftFingerId;
    float halfScreenWidth;

    public Transform cameraTransform;
    public float cameraSense;

    UnityEngine.Vector2 lookInput;
    float cameraVerticalRotation;

    public CharacterController characterController;

    public static float moveSpeed = 2f;
    public float moveInputDeadZone;

    UnityEngine.Vector2 moveTouchStartPosition;
    UnityEngine.Vector2 moveInput;



// Stoyan's gravity code START
    public float gravity = -9.81f;
    private CharacterController controller;
    private UnityEngine.Vector3 velocity;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;

    // Stoyan's gravity code END

    [SerializeField] private string sceneToLoad;
    public static string m_SceneToLoad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //default value of not being pressed at the start =-1
        rightFingerId = -1;
        leftFingerId = -1;

        // divide the screen in half
        halfScreenWidth = Screen.width / 2;

        //calculate the movement input dead zone (the area on which subtle finger movement won't affect actual movement)
        moveInputDeadZone = Mathf.Pow(Screen.height / moveInputDeadZone, 2);


        controller = GetComponent<CharacterController>();
        m_SceneToLoad = sceneToLoad;
    }

    // Update is called once per frame
    void Update()
    {
        TrackTouchInput();

        //check if right finger is being pressed, and if so, allow to rotate the camera around
        if (rightFingerId != -1)
        {
            LookAround();
        }
        //check if the left finger is being pressed, and if so, move the player
        if (leftFingerId != -1)
        {
            Move();
        }


        //Stoyan Gravity Code START

        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // small downward force to keep grounded
        }
         //Stoyan Gravity Code END

    }

    void TrackTouchInput()
    {
        // check all touches on the screen
        for (int i = 0; i < Input.touchCount; i++)
        {

            Touch touch = Input.GetTouch(i);

            // Check the phase of each touch
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // if the touch is on the "movement" (left) side of the screen and there isn't another finger pressing on that side..
                    if (touch.position.x < halfScreenWidth && leftFingerId == -1)
                    {
                        // this touch will start being tracked as the left finger, and as its ID is different than -1, other touches after that will be ignored
                        leftFingerId = touch.fingerId;

                        // start position of the movement control finger
                        moveTouchStartPosition = touch.position;
                    }

                    // same thing as above, but for the "rotate camera" (right) half of the screen
                    else if (touch.position.x > halfScreenWidth && rightFingerId == -1)
                    {
                        rightFingerId = touch.fingerId;
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:

                    // when the touch is released, it resets the values for left and right finger IDs back to -1
                    if (touch.fingerId == leftFingerId)
                    {
                        leftFingerId = -1;
                    }

                    else if (touch.fingerId == rightFingerId)
                    {
                        rightFingerId = -1;
                    }
                    break;

                case TouchPhase.Moved:

                    // if the current tracked finger has moved, update lookInput
                    if (touch.fingerId == rightFingerId)
                    {
                        lookInput = touch.deltaPosition * cameraSense * Time.deltaTime;
                    }

                    else if (touch.fingerId == leftFingerId)
                    {
                        moveInput = touch.position - moveTouchStartPosition;
                    }
                    break;

                case TouchPhase.Stationary:

                    // if the finger is still, the lookInput (look around) is set to 0,0
                    if (touch.fingerId == rightFingerId)
                    {
                        lookInput = UnityEngine.Vector2.zero;
                    }
                    break;
            }
        }
    }
    // function to rotate the camera
    void LookAround()
    {
        // check camera vertical rotation value and apply it to the camera transform
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation - lookInput.y, -90f, 90f);
        cameraTransform.localRotation = UnityEngine.Quaternion.Euler(cameraVerticalRotation, 0, 0);

        // horizontal rotation
        transform.Rotate(transform.up, lookInput.x);
    }

    void Move()
    {
        // dont move if the touch distance is shorter than the "dead zone"
        if (moveInput.sqrMagnitude <= moveInputDeadZone) return;

        UnityEngine.Vector2 movementDirection = moveInput.normalized * moveSpeed * Time.deltaTime;

        characterController.Move(transform.right * movementDirection.x + transform.forward * movementDirection.y);
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("SceneChanger"))
        {
            SceneManager.LoadScene(m_SceneToLoad);
        }
    }
}
