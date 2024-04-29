using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    public enum RotationAxes { // Define an enum data structure to associate names with settings
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2 // these names are different from the ones defined by Unity for GetAxis()
    }
    
    public RotationAxes axes = RotationAxes.MouseXAndY; // Axes variable creation and initialization
    public float sensitivityHor = 8.0f;
    public float sensitivityVert = 8.0f;

    // Limits for vertical rotation:
    public float minVert = -90.0f;
    public float maxVert = 90.0f;

    private float verticalRot = 0; // private variable for vertical angle, init to 0

    void Start() { // freeze rotation on rigidbody
        Rigidbody body = GetComponent<Rigidbody> ();
        if (body != null) {
            body.freezeRotation = true;
        }
    }

    void Update()
    {
        if (axes == RotationAxes.MouseX) {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);   // order in () are x, y, z. mouse sensed on x axis, so spins on y
        }
        else if (axes == RotationAxes.MouseY) {
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert; // remove value (defined by mouse move, which updates and increments per frame) from the rotation angle 
            verticalRot = Mathf.Clamp(verticalRot, minVert, maxVert); // clamp vertical angle between min and max limits
                                                                        // Mathf is a class, Clamp is a function to set min and max limits

            float horizontalRot = transform.localEulerAngles.y; // keep same y angle (no horizontal rotation)

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0); // create new vector from the stored rotation values
        }
        else {
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert; // same as line 28
            verticalRot = Mathf.Clamp(verticalRot, minVert, maxVert); // same as line 29

            float delta = Input.GetAxis("Mouse X") * sensitivityHor; // "delta" represents amount to change the rotation by (like delta in blender)
            float horizontalRot = transform.localEulerAngles.y + delta; // increment the rotation angle by delta (add the rotation to the transform)

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);

        }
    }
}
