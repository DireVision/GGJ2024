using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float timer = 2.0f;


    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        timer -= dt;
        Debug.Log(timer);

        if (timer <= 0.0f) {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            dt = 0.0f;
            timer = 2.0f;
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
