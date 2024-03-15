using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 9;
    [SerializeField] private float jumpForce = 19;

    private Rigidbody2D rb;

    [SerializeField] private bool grounded; 
    [SerializeField] private LayerMask whatIsGround;
    
    private Collider2D myCollider;

    private Animator anim;

    // [SerializeField] private bool hasJumped; // bool to hold that jump has finished

    [SerializeField] private bool performingJump;

    private enum MovementState { idle, jumping, falling }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        whatIsGround = LayerMask.GetMask("Ground");

        anim = GetComponent<Animator>();

    }

    void Update() 
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround); // returns true if layers are touching

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && grounded == true) // check spacebar down
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // perform jump
        }

        JumpAndAnimate();
    
    }

    // private void JumpAndAnimate()
    // {
    //     if(Input.GetKeyDown(KeyCode.Space)) // check spacebar down
    //     {
    //         if(grounded == true && anim.GetBool("Jumping") == false && hasJumped == false) // check grounded, Jumping false, hasJump false
    //         {   
    //             rb.velocity = new Vector2(rb.velocity.x, jumpForce); // perform jump

    //             anim.SetBool("Jumping", true); // cue jump animation
    //             // Debug.Log("Jumping");

    //             hasJumped = true; // hasJump registered true

    //         }
    //     }

    //     else if(Input.GetKeyUp(KeyCode.Space) && hasJumped == true) // check spacebar up, hasJump true
    //         {
    //             hasJumped = false; // hasJump reset 
               
    //             // Debug.Log("Has Jumped");
    //         }

    //     else if(grounded == true && hasJumped == false) // check grounded, hasJump false. this way Jumping can be true while grounded.
    //     {
    //         anim.SetBool("Jumping", false);
    //         // Debug.Log("Done Jumping");
    //     } 

    //     anim.SetInteger("State", )
    // }


    private void JumpAndAnimate()
    {
        
        MovementState state = 0;

        if(grounded == true && performingJump == false)
        {
            state = MovementState.idle;

            Debug.Log("Idle.");
        }

        else if (rb.velocity.y > .1f) // check if upward velocity
        {
            state = MovementState.jumping; // cue jump animation

            performingJump = true; // performingJump registered true

            Debug.Log("Performing jump.");
        }

        else if (grounded == false) // check if not grounded, performingJump true
        {
            state = MovementState.falling; // cue falling animation

            performingJump = false;

            Debug.Log("Falling.");

        }

        else if(grounded == true && performingJump == true) // check grounded, performingJump true
        {
            state = MovementState.idle; // cue idle animation

            performingJump = false; // performingJump reset 

            Debug.Log("Grounded.");
        }

        anim.SetInteger("State", (int)state); // cast state enum to int and set the value of State (in animator)

    }


    
}
