using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScript : MonoBehaviour
{
    public int levelToChangeTo;
  
    public void ChangeScene(int buildIndex)
    {

        SceneManager.LoadScene(buildIndex);

    }

    private void OnTriggerEnter2D(Collider2D collision) //Player reaches elevator
    {
        //playerLevel++;
        //Debug.Log(playerLevel);
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelToChangeTo);
            GameObject.Find("Player").GetComponent<PlayerMovement>().health = 3;
        }
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
