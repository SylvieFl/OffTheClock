using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutsceneAudioManager : MonoBehaviour
{

    public AudioSource SFX;

    /*public AudioClip crunch;
    public AudioClip door;
    public AudioClip lanyard;
    public AudioClip mask;
    public AudioClip stapleGunEquip;
    public AudioClip walk;*/


    public void PlayIntroSFX(AudioClip clip)
    { 
        SFX.PlayOneShot(clip);
    }
}
