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

        yield return new WaitForSeconds(3);
        frameTwo.enabled = false;

        yield return new WaitForSeconds(3);
        frameThree.enabled = false;

        yield return new WaitForSeconds(3);
        frameFour.enabled = false;

        yield return new WaitForSeconds(3);
        frameFive.enabled = false;

        yield return new WaitForSeconds(3);
        frameSix.enabled = false;

        yield return new WaitForSeconds(3);
        frameSeven.enabled = false;

        yield return new WaitForSeconds(3);
        frameEight.enabled = false;

        yield return new WaitForSeconds(3);
        frameNine.enabled = false;

        yield return new WaitForSeconds(2);
        buttonOne.gameObject.SetActive(true);

    }

}
