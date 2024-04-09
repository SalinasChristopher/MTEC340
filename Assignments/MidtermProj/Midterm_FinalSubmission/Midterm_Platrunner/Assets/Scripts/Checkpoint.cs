using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private Animator anim;

    [SerializeField] private AudioSource checkpointSound;
    // bool checkpointReached = false;
    
    void Start()
    {
        anim = GetComponent<Animator>(); // assign animator
        anim.SetBool("CheckReached", false);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)  
    {
        if (collision.gameObject.name == "PlayerSq")
        {
            // checkpointSound.Play();
            anim.SetTrigger("Checkpoint");
            // checkpointReached = true;

            Debug.Log("Checkpoint animated.");

        }

    }


    private void CheckReached() // called by Checkpoint_Reached animation event
    {
        anim.SetBool("CheckReached", true);
    }



}
