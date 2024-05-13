using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject optionPanel;

    public Slider sliderSound;
    public Slider sliderSFX;
     

    // Start is called before the first frame update
    void Start()
    {
        sliderSFX.value = PlayerPrefs.GetFloat(Constant.SFX_KEY);
        sliderSound.value = PlayerPrefs.GetFloat(Constant.SOUND_KEY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sound()
    {
        PlayerPrefs.SetFloat(Constant.SOUND_KEY, sliderSound.value);
        SoundManager.Instance.updateVol();
    }

    public void sfx()
    {
        PlayerPrefs.SetFloat(Constant.SFX_KEY, sliderSFX.value);
        SoundManager.Instance.updateVol();
    }

    public void Close()
    {
        optionPanel.SetActive(false);
    }

    public void OpenOption()
    {
        optionPanel.SetActive(true);
    }
    public void Play()
    {
        SceneManager.LoadScene(Constant.CHOOSE_PLANE); 
        
        loadScene();
    }
    public void loadScene()
    {
        string name_scene = SceneManager.GetActiveScene().name;  
    }

}
