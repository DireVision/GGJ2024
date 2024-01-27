using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObject : MonoBehaviour
{
    public bool isAlive = true;
    //run speed/time
    public float MoveSpeed;
    //velocities
    // public float HorizontalSpeed;
    public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isAlive){
            Vector3 forwardMovement = transform.forward * MoveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + forwardMovement);
            // Vector3 horizontalMovement = transform.right *  HorizontalSpeed * Time.fixedDeltaTime;
        }
    }
}
