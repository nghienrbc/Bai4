using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
public class AudioManager : MonoBehaviour
{
    public AudioClip Clip;
    // Static singleton property.
    public static AudioManager Instance { get; private set; }
    void Awake()
    {
        // Save a reference to the AudioManager component as our //singleton instance.
        Instance = this;
    }
    // Instance method, this method can be accessed through the //singleton instance
    public void PlayAudio(AudioClip clip)
    {
        GameObject gameObj = new GameObject("Sound", typeof(AudioSource));
        AudioSource audioSource = gameObj.GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
    }
}
