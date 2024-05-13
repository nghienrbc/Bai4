using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSingleton : MonoBehaviour  
{
    // Biến static để lưu trữ thể hiện duy nhất của GameManager
    private static GameManagerSingleton _instance;

    // Property để truy cập vào thể hiện GameManager
    public static GameManagerSingleton Instance
    {
        get
        {
            // Nếu không có thể hiện nào tồn tại, tạo mới một thể hiện
            if (_instance == null)
            {
                // Tìm đối tượng GameManager trong scene (nếu có)
                _instance = FindObjectOfType<GameManagerSingleton>();

                // Nếu không tìm thấy, tạo một GameObject mới và gắn GameManager vào đó
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(GameManagerSingleton).Name);
                    _instance = singletonObject.AddComponent<GameManagerSingleton>();
                }
            }

            return _instance;
        }
    }


    // Khởi tạo đối tượng GameManager
    private void Awake()
    {
        // Đảm bảo rằng chỉ có một thể hiện của GameManager tồn tại
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject); // Đảm bảo rằng GameManager không bị hủy khi chuyển scene
        }
    }

    // Các phương thức và biến của GameManager có thể được thêm ở đây
    // Ví dụ:
    public void StartGame()
    {
        Debug.Log("Game started!");
    }

    public void EndGame()
    {
        Debug.Log("Game ended!");
    }
}
