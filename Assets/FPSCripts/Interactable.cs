using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string message;
    Color originColor;
    public Color newColor;
    private Renderer renderer;
     
    // Start is called before the first frame update
    //public virtual void Start()
    private void Start()
    {
        Debug.Log("Start in base class");
        //message = gameObject.name;
        renderer = GetComponent<Renderer>();
        originColor = renderer.material.color;
    }
    private void Update()
    {
       ChangeColor();
    }

    public void ShowName()
    {

    }
    public void BaseInteract()
    {
        Interact();
    }


    public virtual void Interact()
    {
       Debug.Log("Base Interact");
        
    }

    void ChangeColor()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            // Nếu ray va chạm với công tắc
            if (hitInfo.collider.gameObject == gameObject)
            {
                renderer.material.color = newColor;
            }
            else
            { 
                renderer.material.color = originColor;

            }
        }
    }
}
