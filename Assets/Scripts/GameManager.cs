using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton <GameManager>
{
    public GameObject enemyPrefab;  // Prefab của đối tượng cần tạo
    public int numberOfObjects = 5;
    public float spacing = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    } 
    public void SpawnEnemy()
    {
        // Sử dụng vòng lặp for để tạo và xếp các đối tượng
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Tạo một đối tượng từ prefab
            GameObject obj = Instantiate(enemyPrefab, new Vector3(i * spacing, 0f, 0f), Quaternion.identity);

            // Đặt tên đối tượng để dễ nhận biết
            obj.name = "Enemy_" + i.ToString();
        }
    }
}
