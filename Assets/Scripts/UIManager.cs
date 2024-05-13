using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI myText;
    private string myString = "";
    // Start is called before the first frame update
    void Start()
    {
        myString = "Unity";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MyButtonClick()
    {
        //Debug.Log(myString);
        myText.GetComponent<TextMeshProUGUI>().text = $"Hello {myString}";
        // gọi phương thức spawn enemy từ đối tượng GameManager
        GameManager.Instance.SpawnEnemy();
        GameManagerSingleton.Instance.StartGame();
        //AudioManager.Instance.PlayAudio(AudioManager.Instance.Clip);
    }
}
