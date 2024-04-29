using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    Door1 door1;
    [SerializeField] GameObject door_1;

    void Awake()
    {
        door1 = door_1.GetComponent<Door1>();
    }
    
    void Start()
    {

    }

    void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // takes a GameObject prarameter and removes the object from the scene
            Debug.Log("First key collected.");

            door1.key0Collected = true;

        }   
    }
}
