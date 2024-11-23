using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeRemaining;
    
   
    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        { 
            timeRemaining -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        }

        /*if (timeRemaining < 5 && timeRemaining > 4)
        {
            //Debug.Log("text turn red");
            
        }*/

        if (timeRemaining < 0)
        {
            timerText.text = "00:00";

            //Add Game Over UI
        }
        

    }
}
