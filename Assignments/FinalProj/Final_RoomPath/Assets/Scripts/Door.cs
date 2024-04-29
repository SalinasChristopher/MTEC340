using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{     
    private Animator anim;
    
    public bool doorIsUnlocked;
    public bool doorIsOpen;

    Material door0_Material;


    void Start ()
    {
        anim = GetComponent<Animator>(); // assign animator
        // anim.SetBool("DoorInRange", false);

        doorIsUnlocked = true;
        
        door0_Material = GetComponent<Renderer>().material;
        SetColorGreen(door0_Material);



    }

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && !doorIsOpen)
        {
            anim.SetTrigger("OpenDoor");
            doorIsOpen = true;
            Debug.Log("Door has been opened.");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1) && doorIsOpen)
        {
            anim.SetTrigger("CloseDoor");
            doorIsOpen = false;
        }
    }

    void OnTriggerEnter(Collider collision) 
    {

        // if(collision.gameObject.name == ("PlayerCapsule") && !doorIsOpen)
        // {
        //     Debug.Log("Trigger enter.");

        //     anim.SetTrigger("DoorInRange");
        //     doorIsOpen = true;

        // } 

        Debug.Log("Press 1 to open/close door.");

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

}
