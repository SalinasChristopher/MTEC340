using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Camera mainCamera;

    // public int weaponDamage; 

    // For shooting
    public bool isShooting, readyToShoot;
    bool allowReset = true;
    public float shootingDelay = 0.5f;

    // Projectiles 
    public GameObject projectilePrefab;
    public Transform projectileSpawn;
    public float projectileVelocity = 100;
    public float projectilePrefabLifeTime = 3f;


    private void Awake()
    {
        readyToShoot = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireWeapon();
        }
    }

    void FireWeapon()
    {
        readyToShoot = false; // To stop from being able to shoot while the first shot is not finished


        // Instantiate projectile
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawn.position, Quaternion.identity); 


        // Shoot projectile
        projectile.GetComponent<Rigidbody>().AddForce(projectileSpawn.forward.normalized * projectileVelocity, ForceMode.Impulse);

        // Destroy projectile after some time
        StartCoroutine(DestroyProjectileAfterTime(projectile, projectilePrefabLifeTime));

        // Checking if shooting is finished
        if (allowReset)
        {
            Invoke("ResetShot", shootingDelay);
            allowReset = false;
        }

    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowReset = true;
    }

    private IEnumerator DestroyProjectileAfterTime(GameObject projectile, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(projectile);

    }
}
