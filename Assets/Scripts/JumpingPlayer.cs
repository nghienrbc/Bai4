using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlayer : MonoBehaviour
{
    private Rigidbody2D body2D;
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        body2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");  
        body2D.velocity = new Vector2(x * moveSpeed, body2D.velocity.y);
 
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        { 
            Jump();
        } 
    }

    private void Jump()
    {
        //rigidbody2D.AddForce(Vector2.up * jumpForce);
        body2D.velocity = new Vector2(body2D.velocity.x, jumpSpeed); 
        isGrounded = false; 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            if (collision.contacts[0].normal.y >= -1f && collision.contacts[0].normal.y < -0.6f)
            {

            }
            else
            {
                isGrounded = true;
            }
        }
    }

}
