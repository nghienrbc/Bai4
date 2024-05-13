using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager2 : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textToShow;
    // Start is called before the first frame update
    void Start()
    {
        
    } 

    public void SetName(string name)
    {
        textToShow.text = name;
    }
}
