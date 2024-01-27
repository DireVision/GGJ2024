using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnObject : MonoBehaviour
{    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Killzone")
        {
            Destroy(gameObject);
        }
	}
}
