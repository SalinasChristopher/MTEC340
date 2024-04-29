using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvmtBehavior : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;
    private float _vInput;
    private float _hInput;

    private Rigidbody _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody>(); // checks if this component type (here, Rigidbody) exists on the GameObject and returns it. else null
    }

    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * MoveSpeed;


        // this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime); // translate along forward axis (z) according to input 
        // this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime); // rotate along up axis (y)       
    }

    void FixedUpdate() 
    {
        // Vector3 rotation = Vector3.up * _hInput;

        // Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);



        
        // _rb.MoveRotation(_rb.rotation * angleRot);
        
    }
}
