using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public class Sound
    {
        [SerializeField] public string name;
        [SerializeField][Range(0,1)] public float defaultVolume;
        [SerializeField] public AudioClip clip;
    }

    AudioSource audioSource;

    public static AudioManager instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null) { instance = this; }
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlaySound(string soundName)
    {

    }
}
