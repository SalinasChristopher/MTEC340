using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
 
    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // assign rb
        anim = GetComponent<Animator>(); // assign animator
    }

    private void OnTriggerEnter2D(Collider2D collision)  
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Respawn();
        }

    }

    private void Respawn()
    {
        rb.bodyType = RigidbodyType2D.Static;

        anim.SetTrigger("Death");
    }
    

    // private void RestartLevel()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }


}
