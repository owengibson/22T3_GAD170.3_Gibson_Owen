using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // INSTRUCTIONS
    //
    // This script must be on a gameobject that has a Character Controller component.
    // It will add that component if the object does not already have it.
    // This is done by the "[RequireComponent(typeof(CharacterController))]" statement on line 3 of this script. (See above.)
    //
    // Also, make a camera a child of this object and tilt it the way you want it to tilt.
    // The mouse will let you turn the character, and therefore, the camera along with it.

    [Header("References")]
    // This must be linked to the gameobject that has the "Character Controller" in the inspector.
    private CharacterController characterController;
    private Camera playerCamera;

    [Header("Movement Variables")]
    // These variables (visible in the inspector) are for you to set up to match the right feel
    [SerializeField] private float movementSpeed = 12f;
    [SerializeField] private float horizontalSpeed = 2.0f;
    [SerializeField] private float verticalSpeed = 2.0f;

    // These two are for the camera movement
    [SerializeField] private float yaw = 0.0f;
    [SerializeField] private float pitch = 0.0f;

    [Header("Jumping Variables")]
    // Determines how high the character can jump.
    [SerializeField] private float jumpHeight = 2f;

    // Customisable gravity. A "more negative" number makes the character fall faster.
    [SerializeField] private float gravity = -20f;

    // So the script knows if you can jump!
    private bool isGrounded;

    // To handle vertical movement
    private Vector3 velocity;

    private void Start()
    {
        // If the variable "characterController" is empty...
        if (characterController == null)
        {
            // ...then this searches the components on the gameobject and gets a reference to the CharacterController class
            characterController = GetComponent<CharacterController>();
        }

        playerCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        // These lines let the script rotate the character based on the mouse moving
        yaw += horizontalSpeed * Input.GetAxis("Mouse X");
        pitch -= verticalSpeed * Input.GetAxis("Mouse Y");

        // Get the Left/Right and Forward/Back values of the input being used (WASD, Joystick etc.)
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");

        // Let the character jump if they are on the ground and they press the jump button
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // Rotate the character based off those mouse values we collected earlier
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        playerCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        // This is stealing the data about the character being on the ground from the character controller
        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // This fakes gravity!
        velocity.y += gravity * Time.deltaTime;

        // This takes the Left/Right and Forward/Back values to build a vector
        Vector3 movementVector = transform.right * xValue + transform.forward * zValue;

        // Finally, it applies that vector it just made to the character
        characterController.Move(movementVector * movementSpeed * Time.deltaTime + velocity * Time.deltaTime);
    }
}
