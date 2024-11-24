using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroCutscene : MonoBehaviour
{
    public RawImage frameOne;
    public RawImage frameTwo;
    public RawImage frameThree;
    public RawImage frameFour;
    public RawImage frameFive;
    public RawImage frameSix;
    public RawImage frameSeven;
    public RawImage frameEight;
    public RawImage frameNine;

    public IntroCutsceneAudioManager introSFX;

    public AudioClip crunch;
    public AudioClip run;
    public AudioClip door;
    public AudioClip lanyard;
    public AudioClip mask;
    public AudioClip stapleGunEquip;
    public AudioClip walk;

    public Button buttonOne;
    
    
    // Start is called before the first frame update
    void Start()
    {
        buttonOne.gameObject.SetActive(false);
        StartCoroutine(CoFlipFrames());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(int buildIndex)
    {

        SceneManager.LoadScene(buildIndex);

    }

    IEnumerator CoFlipFrames()
    {
        yield return new WaitForSeconds(3.25f);
        frameOne.enabled = false;
        introSFX.PlayIntroSFX(walk);
        yield return new WaitForSeconds(1);
        introSFX.PlayIntroSFX(crunch);

        yield return new WaitForSeconds(3);
        frameTwo.enabled = false;
        introSFX.PlayIntroSFX(lanyard);

        yield return new WaitForSeconds(3);
        frameThree.enabled = false;

        yield return new WaitForSeconds(3);
        frameFour.enabled = false;
        introSFX.PlayIntroSFX(run);
        yield return new WaitForSeconds(2);
        introSFX.PlayIntroSFX(door);

        yield return new WaitForSeconds(3);
        frameFive.enabled = false;

        yield return new WaitForSeconds(3);
        frameSix.enabled = false;
        introSFX.PlayIntroSFX(mask);

        yield return new WaitForSeconds(4);
        frameSeven.enabled = false;

        yield return new WaitForSeconds(3);
        frameEight.enabled = false;
        introSFX.PlayIntroSFX(run);

        yield return new WaitForSeconds(3);
        frameNine.enabled = false;
        introSFX.PlayIntroSFX(stapleGunEquip);
        yield return new WaitForSeconds(0.25f);
        introSFX.PlayIntroSFX(run);

        yield return new WaitForSeconds(2);
        buttonOne.gameObject.SetActive(true);

    }

}
