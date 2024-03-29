using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
	public GameObject Object1, Object2, Object3;
	public GameObject Cop, Norm1, Norm2, Taxi;
	public GameObject SUV;
	public GameObject Sports1, Sports2;
	public GameObject PointOrb, HealthOrb;

	float L1PosX = -3.33f; // Lane 1 x-pos of spawner
	float L2PosX = 0.0f; // Lane 2 x-pos of spawner
	float L3PosX = 3.33f; // Lane 3 x-pos of spawner
	float LPosZ = 55f; // All lanes z-pos of spawner
	float LPosY_Upper = 5f;
	float LPosY_Lower = 1f;

	public bool eventHappening = false;

	int maxObjRange = 3;
	public int OrbChanceInRangeOf = 15;
	int randomNumber1, randomNumber2, randomNumber3;
	public float timer = 2.5f;

	// Update is called once per frame
	void Update()
	{
		float dt = Time.deltaTime;
		timer -= dt;
		//Debug.Log(timer);

		if (timer > 1.1f && timer < 1.105f)
		{
			InstantiateLowerOrbs();
		}

		if (timer <= 0.1f) {
			InstantiateObjects();
			InstantiateUpperOrbs();
			dt = 0.0f;
			timer = 2.0f;
		}

		// Press space to spawn HighWall in all lanes
/*		if(Input.GetKeyDown(KeyCode.Space)) {
			Instantiate(Object1, new Vector3(L1PosX, 0f, LPosZ), Quaternion.identity);
			Instantiate(Object1, new Vector3(L2PosX, 0f, LPosZ), Quaternion.identity);
			Instantiate(Object1, new Vector3(L3PosX, 0f, LPosZ), Quaternion.identity);
		}*/
	}

    void InstantiateLowerOrbs()
	{
		randomNumber1 = Random.Range(0, OrbChanceInRangeOf);
		if (randomNumber1 == 0)
		{
			GameObject go = Instantiate(PointOrb, new Vector3(L1PosX, LPosY_Lower, LPosZ), Quaternion.identity);
        }
        if (randomNumber1 == 1)
		{
			GameObject go = Instantiate(HealthOrb, new Vector3(L1PosX, LPosY_Lower, LPosZ), Quaternion.identity);
        }
		randomNumber1 = Random.Range(0, OrbChanceInRangeOf);
		if (randomNumber1 == 0)
		{
			GameObject go = Instantiate(PointOrb, new Vector3(L2PosX, LPosY_Lower, LPosZ), Quaternion.identity);
        }
		if (randomNumber1 == 1)
		{
			GameObject go = Instantiate(HealthOrb, new Vector3(L2PosX, LPosY_Lower, LPosZ), Quaternion.identity);
        }
		randomNumber1 = Random.Range(0, OrbChanceInRangeOf);
		if (randomNumber1 == 0)
		{
			GameObject go = Instantiate(PointOrb, new Vector3(L3PosX, LPosY_Lower, LPosZ), Quaternion.identity);
        }
		if (randomNumber1 == 1)
		{
			GameObject go = Instantiate(HealthOrb, new Vector3(L3PosX, LPosY_Lower, LPosZ), Quaternion.identity);
        }
	}

	void InstantiateObjects()
	{
		int checkNumber = 0;
		int randCar = 0;

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
			GameObject go = Instantiate(Object1, new Vector3(L1PosX, 0f, LPosZ), Quaternion.identity);
            if (eventHappening)
                go.GetComponent<MovementObject>().surpriseObstacle = true;
        }
		if (randomNumber1 == 1){
			randCar = Random.Range(0, 6);
			switch (randCar)
            {
				case 0:
					Object2 = Cop;
					break;
				case 1:
					Object2 = Norm1;
					break;
				case 2:
					Object2 = Norm2;
					break;
				case 3:
					Object2 = Taxi;
					break;
				case 4:
					Object2 = Sports1;
					break;
				case 5:
					Object2 = Sports2;
					break;
			}
			GameObject go = Instantiate(Object2, new Vector3(L1PosX, 0f, LPosZ), Quaternion.identity);
            if (eventHappening)
                go.GetComponent<MovementObject>().surpriseObstacle = true;
        }
		if (randomNumber1 == 2){
			GameObject go = Instantiate(Object3, new Vector3(L1PosX, 0f, LPosZ), Quaternion.identity);
            if (eventHappening)
                go.GetComponent<MovementObject>().surpriseObstacle = true;
        }

		// Lane 2: Spawn Highwall, LowWall, NoWall
		if (randomNumber2 == 0){
			GameObject go = Instantiate(Object1, new Vector3(L2PosX, 0f, LPosZ), Quaternion.identity);
            if (eventHappening)
                go.GetComponent<MovementObject>().surpriseObstacle = true;
        }
		if (randomNumber2 == 1){
			randCar = Random.Range(0, 6);
			switch (randCar)
			{
				case 0:
					Object2 = Cop;
					break;
				case 1:
					Object2 = Norm1;
					break;
				case 2:
					Object2 = Norm2;
					break;
				case 3:
					Object2 = Taxi;
					break;
				case 4:
					Object2 = Sports1;
					break;
				case 5:
					Object2 = Sports2;
					break;
			}
			GameObject go = Instantiate(Object2, new Vector3(L2PosX, 0f, LPosZ), Quaternion.identity);
            if (eventHappening)
                go.GetComponent<MovementObject>().surpriseObstacle = true;
        }
		if (randomNumber2 == 2){
			GameObject go = Instantiate(Object3, new Vector3(L2PosX, 0f, LPosZ), Quaternion.identity);
            if (eventHappening)
                go.GetComponent<MovementObject>().surpriseObstacle = true;
        }

		// Lane 3: Spawn Highwall, LowWall, NoWall
		if (randomNumber3 == 0){
			GameObject go = Instantiate(Object1, new Vector3(L3PosX, 0f, LPosZ), Quaternion.identity);
            if (eventHappening)
                go.GetComponent<MovementObject>().surpriseObstacle = true;
        }
		if (randomNumber3 == 1){
			randCar = Random.Range(0, 6);
			switch (randCar)
			{
				case 0:
					Object2 = Cop;
					break;
				case 1:
					Object2 = Norm1;
					break;
				case 2:
					Object2 = Norm2;
					break;
				case 3:
					Object2 = Taxi;
					break;
				case 4:
					Object2 = Sports1;
					break;
				case 5:
					Object2 = Sports2;
					break;
			}

			GameObject go = Instantiate(Object2, new Vector3(L3PosX, 0f, LPosZ), Quaternion.identity);
            if (eventHappening)
                go.GetComponent<MovementObject>().surpriseObstacle = true;
        }
		if (randomNumber3 == 2){
			GameObject go = Instantiate(Object3, new Vector3(L3PosX, 0f, LPosZ), Quaternion.identity);
            if (eventHappening)
                go.GetComponent<MovementObject>().surpriseObstacle = true;
        }
	}

	void InstantiateUpperOrbs()
	{
		// If Lane 1 did not spawn HighWall, roll if collectible is spanwed
		if (randomNumber1 != 0)
		{
			randomNumber1 = Random.Range(0, OrbChanceInRangeOf);
			if (randomNumber1 == 0)
			{
				Instantiate(PointOrb, new Vector3(L1PosX, LPosY_Upper, LPosZ), Quaternion.identity);
            }
			if (randomNumber1 == 1)
			{
				Instantiate(HealthOrb, new Vector3(L1PosX, LPosY_Upper, LPosZ), Quaternion.identity);
            }
		}

		// If Lane 2 did not spawn HighWall, roll if collectible is spanwed
		if (randomNumber2 != 0)
		{
			randomNumber1 = Random.Range(0, OrbChanceInRangeOf);
			if (randomNumber1 == 0)
			{
				Instantiate(PointOrb, new Vector3(L2PosX, LPosY_Upper, LPosZ), Quaternion.identity);
            }
			if (randomNumber1 == 1)
			{
				Instantiate(HealthOrb, new Vector3(L2PosX, LPosY_Upper, LPosZ), Quaternion.identity);
            }
		}

		// If Lane 3 did not spawn HighWall, roll if collectible is spanwed
		if (randomNumber3 != 0)
		{
			randomNumber1 = Random.Range(0, OrbChanceInRangeOf);
			if (randomNumber1 == 0)
			{
				Instantiate(PointOrb, new Vector3(L3PosX, LPosY_Upper, LPosZ), Quaternion.identity);
            }
			if (randomNumber1 == 1)
			{
				Instantiate(HealthOrb, new Vector3(L3PosX, LPosY_Upper, LPosZ), Quaternion.identity);
            }
		}
	}
}
