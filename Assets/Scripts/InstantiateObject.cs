using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
	public GameObject Object1, Object2, Object3;
	public GameObject PointOrb, HealthOrb;

	float L1PosX = -3.33f; // Lane 1 x-pos of spawner
	float L2PosX = 0.0f; // Lane 2 x-pos of spawner
	float L3PosX = 3.33f; // Lane 3 x-pos of spawner
	float LPosZ = 50f; // All lanes z-pos of spawner
	float LPosY = 5f;

	int maxObjRange = 3;
	int randomNumber1, randomNumber2, randomNumber3;
	public int OrbChanceInRangeOf = 2;
	public float timer = 2.0f;

	// Update is called once per frame
	void Update()
	{
		float dt = Time.deltaTime;
		timer -= dt;
		Debug.Log(timer);

		if (timer <= 0.0f) {
			RandomInstatiate();
			InstantiateUpper();
			dt = 0.0f;
			timer = 2.0f;
		}

		// Press space to spawn HighWall in all lanes
		if(Input.GetKeyDown(KeyCode.Space)) {
			Instantiate(Object1, new Vector3(L1PosX, 0f, LPosZ), Quaternion.identity);
			Instantiate(Object1, new Vector3(L2PosX, 0f, LPosZ), Quaternion.identity);
			Instantiate(Object1, new Vector3(L3PosX, 0f, LPosZ), Quaternion.identity);
		}
	}

	void RandomInstatiate()
	{
		int checkNumber = 0;

		// Check if all walls impossible to beat, if yes, reroll
		while (checkNumber == 0)
		{
			randomNumber1 = Random.Range(0, maxObjRange);
			randomNumber2 = Random.Range(0, maxObjRange);
			randomNumber3 = Random.Range(0, maxObjRange);
			checkNumber = randomNumber1 + randomNumber2 + randomNumber3; 
		}

		// Lane 1: Spawn Highwall, LowWall, NoWall
		if (randomNumber1 == 0){
			Instantiate(Object1, new Vector3(L1PosX, 0f, LPosZ), Quaternion.identity);
		}
		if (randomNumber1 == 1){
			Instantiate(Object2, new Vector3(L1PosX, 0f, LPosZ), Quaternion.identity);
		}
		if (randomNumber1 == 2){
			Instantiate(Object3, new Vector3(L1PosX, 0f, LPosZ), Quaternion.identity);
		}

		// Lane 2: Spawn Highwall, LowWall, NoWall
		if (randomNumber2 == 0){
			Instantiate(Object1, new Vector3(L2PosX, 0f, LPosZ), Quaternion.identity);
		}
		if (randomNumber2 == 1){
			Instantiate(Object2, new Vector3(L2PosX, 0f, LPosZ), Quaternion.identity);
		}
		if (randomNumber2 == 2){
			Instantiate(Object3, new Vector3(L2PosX, 0f, LPosZ), Quaternion.identity);
		}

		// Lane 3: Spawn Highwall, LowWall, NoWall
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

	void InstantiateUpper()
	{
		// If Lane 1 did not spawn HighWall, roll if collectible is spanwed
		if (randomNumber1 != 0)
		{
			randomNumber1 = Random.Range(0, OrbChanceInRangeOf);
			if (randomNumber1 == 0)
			{
				Instantiate(PointOrb, new Vector3(L1PosX, LPosY, LPosZ), Quaternion.identity);
			}
			if (randomNumber1 == 1)
			{
				Instantiate(HealthOrb, new Vector3(L1PosX, LPosY, LPosZ), Quaternion.identity);
			}
		}

		// If Lane 2 did not spawn HighWall, roll if collectible is spanwed
		if (randomNumber2 != 0)
		{
			randomNumber1 = Random.Range(0, OrbChanceInRangeOf);
			if (randomNumber1 == 0)
			{
				Instantiate(PointOrb, new Vector3(L2PosX, LPosY, LPosZ), Quaternion.identity);
			}
			if (randomNumber1 == 1)
			{
				Instantiate(HealthOrb, new Vector3(L2PosX, LPosY, LPosZ), Quaternion.identity);
			}
		}

		// If Lane 3 did not spawn HighWall, roll if collectible is spanwed
		if (randomNumber3 != 0)
		{
			randomNumber1 = Random.Range(0, OrbChanceInRangeOf);
			if (randomNumber1 == 0)
			{
				Instantiate(PointOrb, new Vector3(L3PosX, LPosY, LPosZ), Quaternion.identity);
			}
			if (randomNumber1 == 1)
			{
				Instantiate(HealthOrb, new Vector3(L3PosX, LPosY, LPosZ), Quaternion.identity);
			}
		}
	}
}
