using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeRemaining;

    public RawImage minuteHand;
    public float totalFramesPerSecond;
    public float zRotate;
    //public Vector3 rotatePerFrame;

    public GameOver gameOverScript;

    private void Start()
    {
        //totalFramesPerSecond = timeRemaining * 144;
        zRotate = 360/timeRemaining; // how many degrees per second need to move but it will be interpreted as how many degrees per frame (60 frames per seconds
        zRotate = zRotate * 0.02f;
        zRotate = -Mathf.Abs(zRotate);
        //zRotate = zRotate * 1.8f;
        //zRotate = zRotate / 200;
    }


    void Update()
    {
        if (timeRemaining > 0)
        { 
            timeRemaining -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            //minuteHand.transform.Rotate(0, 0, zRotate);

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
            gameOverScript.GameOverUI();

            //Add Game Over UI
        }
        

    }

    private void FixedUpdate()
    {
        if (timeRemaining > 0) 
        { 
            minuteHand.transform.Rotate(0, 0, zRotate);
        }
        
    }
    IEnumerator TextColorFlicker()
    { 
        timerText.color = Color.red;
        timerText.fontSize = 90;
        Debug.Log("Red");

        yield return new WaitForSeconds(1f);

        timerText.color = Color.white;
        timerText.fontSize = 80;
        Debug.Log("White");

        yield return new WaitForSeconds(1f);

        timerText.color = Color.red;
        timerText.fontSize = 90;
        Debug.Log("Red");

        yield return new WaitForSeconds(1f);

        timerText.color = Color.white;
        timerText.fontSize = 80;
        Debug.Log("White");

        yield return new WaitForSeconds(1f);

        timerText.color = Color.red;
        timerText.fontSize = 90;
        Debug.Log("Red");

        yield return new WaitForSeconds(1f);

        timerText.color = Color.white;
        timerText.fontSize = 80;
        Debug.Log("White");

        yield return new WaitForSeconds(1f);
    }
}
