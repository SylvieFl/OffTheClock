using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutsceneAudioManager : MonoBehaviour
{

    public AudioSource SFX;

  
    public void PlayIntroSFX(AudioClip clip)
    { 
        SFX.PlayOneShot(clip);
    }
}
