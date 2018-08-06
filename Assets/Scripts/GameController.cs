using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    public float totalTimer = 30f;
    private float timeVariation = 1f; // jumps from a second to another and so.
    private float currentTimer;

    private bool isTimerOn = true;

    [Header("Win Panel objects")]
    public GameObject winPanel;
    public Text timerText;
    public Text headerText;
    public Animator starAnimator;
    //public Image[] starsOn;

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
        winPanel.SetActive(true);

        int currentTimerRound = ((int)currentTimer + 1);
        
        if (currentTimerRound >= totalTimer/2)
        {
            headerText.text = "Perfect!";
            starAnimator.Play("WinPanelThreeStars");}

        if ( 0 < currentTimerRound && currentTimerRound < totalTimer/2)
        {
            headerText.text = "Well Done";
            starAnimator.Play("WinPanelTwoStars");
        }

        if (currentTimerRound == 0)
        {
            headerText.text = "Good";
            starAnimator.Play("WinPanel");
        }
    } 
}
