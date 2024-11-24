using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverScreen;
    public GameObject player;
    
    public int lives;
    public RawImage fullLife;
    public RawImage twoLife;
    public RawImage oneLife;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lives = player.GetComponent<PlayerMovement>().health;
        //Debug.Log(lives);

        if (lives == 2)
        { 
            fullLife.enabled = false;
        }

        if (lives == 1)
        {
            twoLife.enabled = false;
        }

        if (lives == 0)
        {
            oneLife.enabled = false;
        }
    }

    public void GameOverUI()
    { 
        gameOverScreen.SetActive(true);
        player.SetActive(false);
    }

    public void RestartButton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void QuitButton()
    {
        
        SceneManager.LoadScene(0);
        //Application.Quit();

    }
}
