using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObject : MonoBehaviour
{
    public float MoveSpeed;

    private void FixedUpdate()
    {
            Vector3 forwardMovement = transform.forward * MoveSpeed * Time.fixedDeltaTime;
            transform.position -= forwardMovement;
    }
}
