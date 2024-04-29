using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public int projectileDamage = 20;
    
    private void OnCollisionEnter(Collision objectHit)
    {
        // if(objectHit.gameObject.CompareTag("Target"))
        // {
        //     Debug.Log("Hit" + collision.gameObject.name + "!");
        //     Destroy(gameObject);
        // }    

        if(objectHit.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hit wall.");
            Destroy(gameObject);
        }
       
        if(objectHit.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy.");

            objectHit.gameObject.GetComponent<Enemy>().TakeDamage(projectileDamage);
            Destroy(gameObject);
        }
    }
}
