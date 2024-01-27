using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
	public GameObject Object1, Object2, Object3;
	public float timer = 2.0f;
	int maxRange = 3;

	[SerializeField] float L1PosX = -3.33f; // Lane 1 x-pos of spawner
	[SerializeField] float L2PosX = 0.0f; // Lane 2 x-pos of spawner
	[SerializeField] float L3PosX = 3.33f; // Lane 3 x-pos of spawner
	float LPosZ = 50f; // All lanes z-pos of spawner

	// Update is called once per frame
	void Update()
	{
		float dt = Time.deltaTime;
		timer -= dt;
		Debug.Log(timer);


		for (int i = 0;  i < 3; i++)
		{
			
		}

		if (timer <= 0.0f) {
			RandomInstatiate();
			dt = 0.0f;
			timer = 2.0f;
		}

		if(Input.GetKeyDown(KeyCode.Space)) {
			Instantiate(Object1, new Vector3(-3.33f, 0f, 0f), Quaternion.identity);
			Instantiate(Object1, new Vector3(0f, 0f, 0f), Quaternion.identity);
			Instantiate(Object1, new Vector3(3.33f, 0f, 0f), Quaternion.identity);
		}
	}

	void RandomInstatiate()
	{
		int checkNumber = 0;
		int randomNumber1 = 0, randomNumber2 = 0, randomNumber3 = 0;

		while (checkNumber == 0)
		{
			randomNumber1 = Random.Range(0, maxRange);
			randomNumber2 = Random.Range(0, maxRange);
			randomNumber3 = Random.Range(0, maxRange);
			checkNumber = randomNumber1 + randomNumber2 + randomNumber3; // Check if all walls impossible to beat
		}

		if (randomNumber1 == 0){
			Instantiate(Object1, new Vector3(L1PosX, 0f, LPosZ), Quaternion.identity);
		}
		if (randomNumber1 == 1){
			Instantiate(Object2, new Vector3(L1PosX, 0f, LPosZ), Quaternion.identity);
		}
		if (randomNumber1 == 2){
			Instantiate(Object3, new Vector3(L1PosX, 0f, LPosZ), Quaternion.identity);
		}

		if (randomNumber2 == 0){
			Instantiate(Object1, new Vector3(L2PosX, 0f, LPosZ), Quaternion.identity);
		}
		if (randomNumber2 == 1){
			Instantiate(Object2, new Vector3(L2PosX, 0f, LPosZ), Quaternion.identity);
		}
		if (randomNumber2 == 2){
			Instantiate(Object3, new Vector3(L2PosX, 0f, LPosZ), Quaternion.identity);
		}

		if (randomNumber3 == 0){
			Instantiate(Object1, new Vector3(L3PosX, 0f, LPosZ), Quaternion.identity);
		}
		if (randomNumber3 == 1){
			Instantiate(Object2, new Vector3(L3PosX, 0f, LPosZ), Quaternion.identity);
		}
		if (randomNumber3 == 2){
			Instantiate(Object3, new Vector3(L3PosX, 0f, LPosZ), Quaternion.identity);
		}
	}


}
