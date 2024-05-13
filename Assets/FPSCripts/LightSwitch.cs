using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    public GameObject lightObject;
    //Color originColor;
    //private Renderer renderer;
    // Start is called before the first frame update
 

    // Update is called once per frame
    //void Update()
    //{
        //Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        //RaycastHit hitInfo;
        //if (Physics.Raycast(ray, out hitInfo))
        //{
        //    // Nếu ray va chạm với công tắc
        //    if (hitInfo.collider.gameObject == gameObject)
        //    {
        //        renderer.material.color = Color.blue;
        //    }
        //    else
        //    {
        //        renderer.material.color = originColor;
        //    }
        //}
    //}
    // Hàm bật/tắt đèn
    void ToggleLight()
    {
        lightObject.SetActive(!lightObject.activeSelf);
    }

    public override void Interact()
    {
        base.Interact();

        // Kiểm tra nếu người chơi nhấn nút chuột trái
        if (Input.GetButtonDown("Fire1"))
        {
            // Bật hoặc tắt đèn
            ToggleLight();
        }
    }

}
