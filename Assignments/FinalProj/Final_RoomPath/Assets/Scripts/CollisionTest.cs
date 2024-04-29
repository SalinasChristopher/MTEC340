using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) 
    {
        if(collision.gameObject.name == ("PlayerCapsule"))
        {
            Debug.Log("Collision triggered.");
        }    

        // Debug.Log(collision.gameObject.name);
    }
}
