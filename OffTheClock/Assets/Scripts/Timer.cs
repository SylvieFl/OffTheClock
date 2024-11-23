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

        if (timeRemaining < 120 && timeRemaining > 119.5)
        {
            StartCoroutine(TextColorFlicker());  
        }

        if (timeRemaining < 60 && timeRemaining > 59.5)
        {
            StartCoroutine(TextColorFlicker());
        }

        if (timeRemaining < 6 && timeRemaining > 5.5)
        {
            StartCoroutine(TextColorFlicker());
        }

        if (timeRemaining < 0)
        {
            timerText.text = "00:00";

            //Add Game Over UI
        }
        

    }

    IEnumerator TextColorFlicker()
    { 
        timerText.color = Color.red;
        timerText.fontSize = 120;
        Debug.Log("Red");

        yield return new WaitForSeconds(1f);

        timerText.color = Color.white;
        timerText.fontSize = 100;
        Debug.Log("White");

        yield return new WaitForSeconds(1f);

        timerText.color = Color.red;
        timerText.fontSize = 120;
        Debug.Log("Red");

        yield return new WaitForSeconds(1f);

        timerText.color = Color.white;
        timerText.fontSize = 100;
        Debug.Log("White");

        yield return new WaitForSeconds(1f);

        timerText.color = Color.red;
        timerText.fontSize = 120;
        Debug.Log("Red");

        yield return new WaitForSeconds(1f);

        timerText.color = Color.white;
        timerText.fontSize = 100;
        Debug.Log("White");

        yield return new WaitForSeconds(1f);
    }
}
