using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CammeraController : MonoBehaviour
{
    public Transform orientation; // lưu hướng của player
    public float lookSpeed; // lưu tốc độ xoay của camera
    Vector2 mouseDirection; // Lưu hướng di chuyển mouse
    float rotationX; // lưu góc xoay theo trục x
    float rotationY; // lưu góc xoay theo trục y
    // Start is called before the first frame update
    void Start()
    {
        // Khóa mouse trong game
        Cursor.lockState = CursorLockMode.Locked;
      //  Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseDirection.x = Input.GetAxisRaw("Mouse X") * lookSpeed * Time.deltaTime;
        mouseDirection.y = Input.GetAxisRaw("Mouse Y") * lookSpeed * Time.deltaTime;

        rotationY += mouseDirection.x; // góc xoay theo trục x do giá trị rê chuột theo chiều ngang Mouse X
        rotationX -= mouseDirection.y; // góc xoay theo trục y do giá trị rê chuột theo chiều dọc Mouse Y
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);  // giới hạn góc xoay theo trục X

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        orientation.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
