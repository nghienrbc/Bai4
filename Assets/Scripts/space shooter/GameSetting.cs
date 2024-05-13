using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : Singleton<GameSetting>
{  
    public static Vector2 sizeCam;
    public static Vector2 positionCam;

    void Awake()
    { 
        sizeCam = new Vector2(2f * Camera.main.aspect * Camera.main.orthographicSize, 2f * Camera.main.orthographicSize);
        //Debug.Log(sizeCam);
        positionCam = Camera.main.transform.position; 
    }  
}
