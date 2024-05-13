using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : Interactable
{
    public GameObject door;

  
    public override void Interact()
    {
        //base.Interact();
        if (Input.GetKey(KeyCode.E))
        { 
        StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        float height = door.transform.position.y + 5f;
        while (door.transform.position.y < height)
        {
            door.transform.position += Vector3.up * 0.5f * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
    }

}
