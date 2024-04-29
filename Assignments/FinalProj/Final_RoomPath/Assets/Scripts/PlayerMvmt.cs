using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvmt : MonoBehaviour
{
    
    private CharacterController controller; // instead of Rigidbody

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    bool isMoving;

    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);

    //~~~~~~~~~~~//
    private Rigidbody _rb;
    

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Ground check. Creates a sphere at the groundCheck position and checks if that position is inside the distance (if its touching the ground layer)
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Resseting the default velocity
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Getting inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Creating the moving vector
        Vector3 move = transform.right * x + transform.forward * z; // (right -- red (x) axis, forward -- blue (z) axis)

        // Actually moving the player
        controller.Move(move * speed * Time.deltaTime);

        // Check if the player can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Jumping up
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            Debug.Log("Spacebar pressed.");
        }

        // Falling down
        velocity.y += gravity * Time.deltaTime;

        // Executing the jump
        controller.Move(velocity * Time.deltaTime); 

        if (lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
            // for later

        }
        else
        {
            isMoving = false;
            // for later

        }

        lastPosition = gameObject.transform.position;  




    }
}
