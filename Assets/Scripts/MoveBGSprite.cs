using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBGSprite : MonoBehaviour
{
    public float speed = 1.0f;
    public float scaleMultiplier = 0.1f; // Điều chỉnh độ phóng to hoặc thu nhỏ của sprite
    public SpriteRenderer bgRenderer;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GetComponent<SpriteRenderer>().bounds.size.y);
        float height = GameSetting.sizeCam.y;
        float width = GameSetting.sizeCam.x;
        Debug.Log(GameSetting.sizeCam);
        Vector2 spriteSize = bgRenderer.bounds.size;  
        float scaleX = width / spriteSize.x * scaleMultiplier;
        float scaleY = height / spriteSize.y * scaleMultiplier;
        //transform.localScale = new Vector3((width + 1) / 10, -(height + 1) / 10, 1.0f);
        transform.localScale = new Vector3(scaleX, scaleY, 1f);
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0);
        if (transform.position.y <= -16.09f)
        {
            transform.position = new Vector3(0.0f, transform.position.y + GetComponent<SpriteRenderer>().bounds.size.y *2, 0);
        }
    }
}
