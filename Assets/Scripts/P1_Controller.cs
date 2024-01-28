using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
	//bools
	public bool isRunning = false;
	public bool isPaused = false;
	public bool isAlive = true;

	//run speed/time
	public float RunSpeed;
	//public float RunTime;
	//velocities
	public float HorizontalSpeed;
	//public float VerticalSpeed;
	float horizontalInput;
	float verticalInput;

	float gravityScale = 5f; // Change this value to accelerate/decelerate jump & fall speed
	public static float globalGravity = -9.81f;

	public Rigidbody rb;

	public LevelManager LM;

	[SerializeField] private float Jumpforce = 350;
	[SerializeField] private LayerMask GroundMask;


	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		if (isAlive)
		{
/*            Vector3 forwardMovement = transform.forward * RunSpeed * Time.fixedDeltaTime;*/
			Vector3 horizontalMovement = transform.right * horizontalInput * HorizontalSpeed * Time.fixedDeltaTime;

			rb.MovePosition(rb.position + horizontalMovement);

			// Hardset z-position of player to 8
			rb.transform.position = SetZ(rb.transform.position, 8);

			// Implementation of gravity with scale
			Vector3 gravity = globalGravity * gravityScale * Vector3.up;
			rb.AddForce(gravity, ForceMode.Acceleration);

			if(rb.transform.position.x <= -2.4f)
			{
				rb.transform.position = SetX(rb.transform.position, -3.6f);
			}
			else if(rb.transform.position.x >= 1.2f)
			{
				rb.transform.position = SetX(rb.transform.position, 2.4f);
            }
			else
			{
				rb.transform.position = SetX(rb.transform.position, -0.6f);
            }
		}
	}
	
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		horizontalInput = Input.GetAxis("Horizontal");

		float playerHeight = GetComponent<Collider>().bounds.size.y;
		bool IsGrounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight / 2) + 0.1f, GroundMask);

		if (Input.GetKeyDown(KeyCode.W) && isAlive && IsGrounded == true)
		{
			Jump();
		}
	}

	public void Jump()
	{
		rb.AddForce(Vector3.up * Jumpforce);
	}

	// Return
	private Vector3 SetZ(Vector3 vector, float z)
	{
		vector.z = z;
		return vector;
	}

	private Vector3 SetX(Vector3 vector, float x)
	{
		vector.x = x;
		return vector;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Obstacle")
		{
			Destroy(other.gameObject);
			LM.lives -= 1;
		}
		if (other.gameObject.tag == "Collectible")
		{
			Destroy(other.gameObject);
			LM.score += 1000;
		}
	}
}
