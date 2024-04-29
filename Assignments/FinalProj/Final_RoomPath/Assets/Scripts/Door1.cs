using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{     
    private Animator anim;
    
    public bool key0Collected;
    public bool key1Collected;
    public bool doorIsUnlocked;
    public bool doorIsOpen;

    Material door1_Material;

    void Start ()
    {
        anim = GetComponent<Animator>(); // assign animator
        // anim.SetBool("DoorInRange", false);

        door1_Material = GetComponent<Renderer>().material;

        doorIsUnlocked = false;
        doorIsOpen = false;

        SetColorRed(door1_Material);
        
    }

    void Update ()
    {
        if (key0Collected && key1Collected)
        {
            doorIsUnlocked = true;
            // Debug.Log("Door has been unlocked.");

            SetColorGreen(door1_Material);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) && doorIsUnlocked && !doorIsOpen)
        {
            anim.SetTrigger("OpenDoor");
            doorIsOpen = true;
            Debug.Log("Door has been opened.");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) && doorIsOpen)
        {
            anim.SetTrigger("CloseDoor");
            doorIsOpen = false;
        }
    }

    void OnTriggerEnter(Collider collision) 
    {
        if (doorIsUnlocked)
        {
            Debug.Log("Press 2 to open/close door.");
        }
        else
        {
            Debug.Log("Door is locked!");

        }

    }

    // void OnTriggerExit(Collider collision) 
    // {

    //     if(collision.gameObject.name == ("PlayerCapsule") && doorIsOpen)
    //     {
    //         Debug.Log("Trigger exit.");

    //         anim.SetTrigger("DoorOutOfRange");
    //         // anim.SetTrigger("DoorOpen");
    //         doorIsOpen = false;
    //     } 

    // }

    void SetColorGreen(Material material)
    {
        material.color = Color.green;
    }

    void SetColorRed(Material material)
    {
        material.color = Color.red;
    }

}
