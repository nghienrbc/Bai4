using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float detectionRange = 2f;
    public float fadeDuration = 2f; // thời gian mờ dần của enemy
    public Color newColor = Color.red;  // Màu mới muốn thiết lập
    private Color originalColor;

    private Renderer objRenderer;
    private Material myMaterial;

    // Start is called before the first frame update
    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        myMaterial = objRenderer.material;
        // Lấy vật liệu của đối tượng hiện tại
        originalColor = myMaterial.color;


        //StartCoroutine(FademyMaterial());
    }

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra xem có đối tượng nào ở gần không
        if (IsPlayerNearby())
        {

            // Thiết lập màu mới cho vật liệu
           // myMaterial.color = newColor;

            // Bắt đầu coroutine
            StartCoroutine(FademyMaterial());
        }
        else
        {

            // Thiết lập màu gốc cho vật liệu
            //myMaterial.color = originalColor;

            // Nếu không, thực hiện một hành động khác
           // Debug.Log("Player is not nearby.");
        }
    }

    bool IsPlayerNearby()
    {
        // Lấy vị trí của người chơi
        Vector3 playerPosition = GameObject.FindWithTag("Player").transform.position;

        // Tính khoảng cách giữa đối tượng hiện tại và người chơi
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

        // Kiểm tra xem khoảng cách có nằm trong phạm vi cho phép không
        return distanceToPlayer < detectionRange;
    }

    IEnumerator FademyMaterial()
    {
        // Lấy màu hiện tại của vật liệu
        Color startColor = myMaterial.color;
        // Thiết lập màu đích là màu trong suốt
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            // Tính toán màu mới dựa trên thời gian đã trôi qua
            myMaterial.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
            // Tăng thời gian đã trôi qua
            elapsedTime += Time.deltaTime;
            // Chờ một frame
            yield return null;
        }
        // Đảm bảo đối tượng cuối cùng có màu chính xác
        myMaterial.color = targetColor;
        // In ra thông báo khi làm mờ hoàn thành
        Debug.Log("Fade complete!");
    }
}
