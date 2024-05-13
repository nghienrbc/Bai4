using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject ballPrefab; // Prefab của quả banh
    public Transform launchPoint; // Điểm bắn của quả banh
    public float shootForce = 10f; // Lực phóng banh

    public float rayDistance;
    public LayerMask layerMask;

    UIManager2 uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.FindObjectOfType<UIManager2>();
    }

    // Update is called once per frame
    void Update()
    { 
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward * rayDistance);
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * rayDistance, Color.yellow);
        // Tạo một biến RaycastHit để lưu trữ thông tin về điểm va chạm
        RaycastHit hitInfo;
        uiManager.SetName(string.Empty);
        if (Physics.Raycast(ray, out hitInfo, rayDistance, layerMask))
        {
            Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
            // nếu ray chạm vào các đối tượng có layermassk là interactable
            if (interactable != null)
            {
                uiManager.SetName(interactable.message);
                //Debug.Log(interactable.message);
                interactable.Interact();
            } 
        } 
        CheckClickMouse();
    }

    void CheckClickMouse()
    { 
        if (Input.GetButtonDown("Fire1"))
        {
            // Chuyển đổi vị trí click chuột từ màn hình sang không gian thế giới
            Vector3 targetPosition = GetTargetPosition();
            //Debug.DrawLine(targetPosition, launchPoint.position, Color.red);
            // Tính toán hướng phóng của banh
            Vector3 shootDirection = (targetPosition - launchPoint.position).normalized;
            Debug.DrawRay(launchPoint.position, shootDirection * 20f, Color.red, 20f);
            // Tạo một instance mới của quả banh tại điểm bắn
            GameObject ballInstance = Instantiate(ballPrefab, launchPoint.position, Quaternion.identity);

            // Lấy tham chiếu đến Rigidbody của banh
            Rigidbody ballRigidbody = ballInstance.GetComponent<Rigidbody>();

            // Áp dballRigidbodyụng lực để phóng banh theo hướng tính toán được
            ballRigidbody.velocity = shootDirection * shootForce;
            //ballRigidbody.AddForce(shootDirection * shootForce, ForceMode.Impulse); 
        }
    }
    Vector3 GetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            return hit.point;
        }

        return transform.forward * 100f; // Nếu không có hit, trả về vị trí ở phía trước player
    }

   
}
