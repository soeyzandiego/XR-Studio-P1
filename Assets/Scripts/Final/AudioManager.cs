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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
