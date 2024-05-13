using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform orientation;
    public float moveSpeed;
    Rigidbody rb;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    [Header("Ground Check")]
    public float playHeight;
    public LayerMask groundLayer;
    bool isGrounded = false;
    public float groundDrag = 5f; 
    public float jumpSpeed = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playHeight * 0.5f + 0.1f, groundLayer);
        if (isGrounded) rb.drag = groundDrag;
        else rb.drag = 0;

    }

    void GetInput()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (isGrounded) rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
        else rb.AddForce(moveDirection.normalized * moveSpeed * 0.4f, ForceMode.Force);
    }

    void Jump()
    {
        Debug.Log("Jump");
        rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
    }
}
