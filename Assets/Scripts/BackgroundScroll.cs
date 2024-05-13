using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float speed; 
    [SerializeField]
    private Renderer bgRenderer;
    public float scaleMultiplier = 0.1f; // Điều chỉnh độ phóng to hoặc thu nhỏ của đối tượng 
    // Start is called before the first frame update
    void Start()
    {
        float height = GameSetting.sizeCam.y;
        float width = GameSetting.sizeCam.x; 
        transform.localScale = new Vector3((width + 1) / scaleMultiplier, -(height + 1) / scaleMultiplier, 1.0f);
    } 
    // Update is called once per frame
    void Update()
    { 
        bgRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime); 
    }
}
