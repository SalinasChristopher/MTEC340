using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // [SerializeField] private float moveSpeed = 9;
    public float moveSpeed = 9;
    [SerializeField] private float jumpForce = 19;

    private Rigidbody2D rb;

    [SerializeField] private bool grounded; 
    [SerializeField] private LayerMask whatIsGround;
    
    private Collider2D myCollider;

    private Animator anim;

    // [SerializeField] private bool hasJumped; // bool to hold that jump has finished

    [SerializeField] private bool performingJump;

    public enum MovementState { idle, jumping, falling }

    //  

    private PowerUpCollect powerUpCollect;
    [SerializeField] private bool powerUpCollected;

    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource landSound;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        whatIsGround = LayerMask.GetMask("Ground");

        anim = GetComponent<Animator>();
        
        //


    }

    void Update() 
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround); // returns true if layers are touching

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && grounded == true) // check spacebar down
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // perform jump
            
            jumpSound.Play();
        }

        JumpAndAnimate();

    
    }


    private void JumpAndAnimate()
    {
        
        MovementState state = 0;

        if(grounded == true && performingJump == false)
        {
            state = MovementState.idle;

            // Debug.Log("Idle.");
        }

        else if (rb.velocity.y > .1f) // check if upward velocity
        {
            state = MovementState.jumping; // cue jump animation

            performingJump = true; // performingJump registered true

            // Debug.Log("Performing jump.");
        }

        else if (grounded == false) // check if not grounded, performingJump true
        {
            state = MovementState.falling; // cue falling animation

            performingJump = false;

            // Debug.Log("Falling.");

        }

        else if(grounded == true && performingJump == true) // check grounded, performingJump true
        {
            state = MovementState.idle; // cue idle animation

            performingJump = false; // performingJump reset 

            // Debug.Log("Grounded.");
        }

        anim.SetInteger("State", (int)state); // cast state enum to int and set the value of State (in animator)

    }


    
}
