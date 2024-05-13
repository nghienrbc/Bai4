using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementVerlocity : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    rb.velocity = new Vector3(0, 0, 5);
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    rb.velocity = new Vector3(0, 0, -5);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    rb.velocity = new Vector3(-5, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    rb.velocity = new Vector3(5, 0, 0);
        //}
        if (Input.GetButtonDown("Jump"))
        { 
            rb.velocity = new Vector3(rb.velocity.x, 5, rb.velocity.z);
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalInput * speed, rb.velocity.y, verticalInput * speed);
    }
}
