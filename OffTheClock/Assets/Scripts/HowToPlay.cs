using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{
    
    public Button buttonOne;
    public GameObject readyToPlayScreen;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoContinueButtonAppear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadyToPlayUI()
    {
        readyToPlayScreen.SetActive(true);
        
    }

    IEnumerator CoContinueButtonAppear() 
    { 
        yield return new WaitForSeconds(3.25f);
        buttonOne.gameObject.SetActive(true);
    }

    public void ChangeScene(int buildIndex)
    {

        SceneManager.LoadScene(buildIndex);

    }

    public void NotReadyToPlayUI()
    {
        readyToPlayScreen.SetActive(false);

    }

}
