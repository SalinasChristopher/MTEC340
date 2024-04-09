using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpCollect : MonoBehaviour
{
    private bool powerUpCollected = false;
    public bool powerUpUsed = false;


    [SerializeField] private Text powerUpText;

    private PlayerBehavior playerBehavior; // referencing an instance of PlayerBehavior class
    private Countdown countdown; // referencing an instance of Countdown class

    [SerializeField] private AudioSource powerUpCollectedSound;
    [SerializeField] private AudioSource slowdownSound;



    private void Start()
    {
        playerBehavior = GetComponent<PlayerBehavior>();
        countdown = GetComponent<Countdown>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            powerUpCollectedSound.Play();

            Destroy(collision.gameObject);

            // Debug.Log("PowerUp Collected.");

            powerUpText.text = "Press Enter to Use SlowDown";

            powerUpCollected = true;            

        } 

    }

    private void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Return) && powerUpCollected == true && !powerUpUsed && countdown.timeUp == false)
        {
            slowdownSound.Play();
            playerBehavior.moveSpeed = 4.5f;
            Debug.Log("Speed is currently: " + playerBehavior.moveSpeed);

            powerUpText.text = "";

            powerUpUsed = true;
        }
        else if(countdown.timeUp == true)
        {
            playerBehavior.moveSpeed = 9f;
        }

    

    }

}
