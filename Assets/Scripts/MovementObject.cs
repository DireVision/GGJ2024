using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObject : MonoBehaviour
{
    public float MoveSpeed;
    private float distance;
    public bool surpriseObstacle;

    private void FixedUpdate()
    {
            Vector3 forwardMovement = transform.forward * MoveSpeed * Time.fixedDeltaTime;
            transform.position -= forwardMovement;

            distance += (MoveSpeed * Time.fixedDeltaTime);
            if (surpriseObstacle && distance >= 30)
            {
            surpriseObstacle = false;
            int random = 0;
            if (transform.position.x < 0)
            {
                random = Random.Range(1, 3);
            }
            else if (transform.position.x > 0)
            {
                random = Random.Range(-2, 0);
            }
            else if (transform.position.x == 0)
            {
                random = Random.Range(-1, 2);
            }
            transform.position = transform.position + new Vector3(random * 3.33f, 0, 1);
        }
    }
}
