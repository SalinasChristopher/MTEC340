using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerRespawn : MonoBehaviour
{
 
    private Rigidbody2D rb;
    private Animator anim;

    //

    private Vector3 respawnPoint;
    [SerializeField] private Text attemptsText;
    private int attempts = 0;

    private PlayerBehavior playerBehavior; // referencing an instance of PlayerBehavior class
    // private Countdown countdown; // referencing an instance of Countdown class

    // public bool hasDied = false;

    [SerializeField] private AudioSource deathSound;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // assign rb
        anim = GetComponent<Animator>(); // assign animator

        // anim.SetBool("Dying", false);
        respawnPoint = transform.position;

        playerBehavior = GetComponent<PlayerBehavior>();
        // countdown = GetComponent<Countdown>();
        

    }

    private void OnTriggerEnter2D(Collider2D collision)  
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();

        }

        else if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
            // Debug.Log("Checkpoint reached.");

        }

    }

    private void Die()
    {
        deathSound.Play();
        
        rb.bodyType = RigidbodyType2D.Static;

        anim.SetTrigger("Death");
        anim.SetBool("Dying", true);



    }

    private void Respawn() // called by death animation event
    {
        transform.position = respawnPoint; // set respawn point to player's current position  
        anim.SetBool("Dying", false);

        playerBehavior.moveSpeed = 9f;

        rb.bodyType = RigidbodyType2D.Dynamic;

        attempts++;
        attemptsText.text = "Attempts: " + attempts;

        // countdown.countdownText.text = "";


    }
    

    // private void RestartLevel() // called by death animation event
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }


}
