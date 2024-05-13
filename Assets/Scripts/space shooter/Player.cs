using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    float minX;
    float maxX;
    float minY;
    float maxY;
    Vector2 playerSize;

    private void Start()
    {
        GetBoundaries();
        playerSize = GetComponent<SpriteRenderer>().bounds.size;
        //Debug.Log(GameSetting.positionCam);
        //Debug.Log(GameSetting.sizeCam);
    }

    private void GetBoundaries()
    {
        //Camera cam = Camera.main;
        //minX = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        //maxX = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        //minY = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        //maxY = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        minX = GameSetting.positionCam.x - GameSetting.sizeCam.x/2;
        maxX = GameSetting.positionCam.x + GameSetting.sizeCam.x/2;
        minY = GameSetting.positionCam.y - GameSetting.sizeCam.y/2;
        maxY = GameSetting.positionCam.y + GameSetting.sizeCam.y/2;

    }
    // Update is called once per frame
    void Update()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");
        float verticalDirection = Input.GetAxis("Vertical");
        float horizontalValue = horizontalDirection * speed * Time.deltaTime;
        float verticallValue = verticalDirection * speed * Time.deltaTime;
         
        //if ((transform.position.x < minX && horizontalDirection < 0 ) ||
        //    (transform.position.x > maxX && horizontalDirection > 0 ))
        //{
        //    horizontalValue = 0;
        //}

        //if ((transform.position.y < minY && verticalDirection < 0) ||
        //    (transform.position.y > maxY && verticalDirection > 0))
        //{ 
        //    verticallValue = 0;
        //}
        transform.position = new Vector2(Mathf.Clamp(transform.position.x + horizontalValue, minX + playerSize.x/2, maxX - playerSize.x/2),
            Mathf.Clamp(transform.position.y + verticallValue, minY + playerSize.y/2, maxY - playerSize.y/2));
    
    }
}
