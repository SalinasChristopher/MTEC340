using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemCollect : MonoBehaviour
{
    private int bonus = 0;

    [SerializeField] private Text bonusText;

    [SerializeField] private AudioSource bonusSound;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Bonus"))
        {
            bonusSound.Play();
            
            Destroy(collision.gameObject);
            
            bonus++;
            bonusText.text = "Bonus: " + bonus + " / 2";
        }

    }

}
