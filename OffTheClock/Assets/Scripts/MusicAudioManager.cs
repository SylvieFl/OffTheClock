using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAudioManager : MonoBehaviour
{
    public AudioSource musicSource;

    public AudioClip bgMusic;


    private void Start()
    {
        musicSource.clip = bgMusic;
        musicSource.Play();
    }
}
