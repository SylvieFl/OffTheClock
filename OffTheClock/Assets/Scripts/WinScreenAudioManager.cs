using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenAudioManager : MonoBehaviour
{
    public AudioSource winSFX;


    public void PlayWinSFX(AudioClip clip)
    {
        winSFX.PlayOneShot(clip);
    }
}
