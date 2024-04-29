using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMvmt : MonoBehaviour
{

    public float mouseSensitivity = 500f;
    public float topClamp = -90f;
    public float bottomClamp = 90f;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        // Locking cursor to middle of screen + making it invisible
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        // Getting mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity *Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity *Time.deltaTime;

        // Rotation around the x axis (look up and down)
        xRotation -= mouseY; // change to += for inverted

        // Clamp rotation
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp); 

        // Rotation around y axis (look L and R)
        yRotation += mouseX;

        // Apply rotations to Player transform
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f); // 0f bc no z rotation



    }
}
 