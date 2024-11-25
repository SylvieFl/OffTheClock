using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{

    public RawImage winScreen;
    public Button quitButton;

    public WinScreenAudioManager winningSFX;
    public AudioClip win;

    // Start is called before the first frame update
    void Start()
    {
        winningSFX.PlayWinSFX(win);
        StartCoroutine(CoFlipFrames());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CoFlipFrames()
    {
        yield return new WaitForSeconds(3.25f);
        winScreen.enabled = false;

        yield return new WaitForSeconds(3);
        quitButton.gameObject.SetActive(true);

    }

    public void QuitButton()
    {

        //SceneManager.LoadScene(0);
        Application.Quit();

    }
}
