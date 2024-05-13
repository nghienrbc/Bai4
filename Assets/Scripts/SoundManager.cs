using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource backGroundSound;
    public float volSound;
    public float volSFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateVol()
    {
        volSound = PlayerPrefs.GetFloat(Constant.SOUND_KEY);
        volSFX = PlayerPrefs.GetFloat(Constant.SFX_KEY);
        soundBackground();
    }

    public void soundBackground()
    {
        backGroundSound.volume = volSound;
    }
}
