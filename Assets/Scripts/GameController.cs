using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    private float totalTimer = 30f;
    private float timeVariation = 1f; // jumps from a second to another and so.
    private float currentTimer;

    private bool isTimerOn = true;

    public Text timerText;

    public Image[] starsOn;

    private void OnEnable()
    {
        currentTimer = totalTimer;
    }

    private void Start()
    {
        
    }

    void Update()
    {
        if (isTimerOn == true)
        {
            currentTimer -= Time.deltaTime * timeVariation;
            timerText.text = ((int)currentTimer + 1).ToString();
            if (currentTimer < -1f)
            {
                isTimerOn = false;
            }
        }
    }

    public void ResetGameTimer()
    {
        currentTimer = totalTimer;
    }

    public void CheckPerformance()
    {
        isTimerOn = false;

        int currentTimerRound = ((int)currentTimer + 1);
        
        if (currentTimerRound >= totalTimer/2)
        {
            foreach (Image image in starsOn)
            {
                image.enabled = true;
            }
        }

        if ( 0 < currentTimerRound && currentTimerRound < totalTimer/2)
        {
            starsOn[0].GetComponent<Image>().enabled = true;
            starsOn[1].GetComponent<Image>().enabled = true;
        }

        if (currentTimerRound == 0)
        {
            starsOn[0].GetComponent<Image>().enabled = true;
        }
    } 
}
