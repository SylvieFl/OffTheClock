using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOverUI()
    { 
        gameOverScreen.SetActive(true);
    }

    public void RestartButton()
    {

        SceneManager.LoadScene(2);

    }

    public void QuitButton()
    {
        
        SceneManager.LoadScene(0);
        //Application.Quit();

    }
}
