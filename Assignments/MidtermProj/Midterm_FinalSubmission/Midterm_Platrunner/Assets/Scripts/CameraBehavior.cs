using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform cameraTarget;

    private Vector3 playerPosition; // create new Vector3 to store the PlayerSq transform info
    private float distanceToMove;

    void Start()
    {

        cameraTarget = GameObject.Find("PlayerSq").transform; // get transform from PlayerSq
        playerPosition = cameraTarget.transform.position; // assign the transform's position to the new Vector3 

    }

    void Update()
    {

        distanceToMove = cameraTarget.transform.position.x - playerPosition.x; // 

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z); 
        // ^ transform of current object the script is attached to

        playerPosition = cameraTarget.transform.position;

    }
}
