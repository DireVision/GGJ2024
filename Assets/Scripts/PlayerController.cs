using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
    public Rigidbody rb;

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
            Vector3 forwardMovement = transform.forward * RunSpeed * Time.fixedDeltaTime;
            Vector3 horizontalMovement = transform.right * horizontalInput * HorizontalSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + forwardMovement + horizontalMovement);
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
        if (Input.GetKeyDown(KeyCode.Space) && isAlive && IsGrounded == true)
        {
            Jump();
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * Jumpforce);
    }
}
