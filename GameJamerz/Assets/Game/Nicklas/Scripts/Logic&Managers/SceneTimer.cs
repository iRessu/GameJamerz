using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTimer : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    public Animator timerTextAnimator;
    [SerializeField] float remainingTime;


    private void Start()
    {
        timerText.color = Color.white;
    }
    // Update is called once per frame
    void Update()
    {
       
        if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            CheckEventAtSpecificTime();
        }
        else if(remainingTime < 0)
        {
            remainingTime = 0;
            GameOver();
        }
        float minutes = Mathf.FloorToInt(remainingTime / 60);
        float seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }


    void CheckEventAtSpecificTime()
    {
        if (remainingTime <= 121f && remainingTime > 120.9f)
        {
            TimerAt3Minutes();
            
        }
        
        if(remainingTime <= 61f && remainingTime > 60.9f)
        {
            TimerAt4Minutes();
        }
    }

    void TimerAt4Minutes()
    {
        timerText.color = Color.red;
        timerTextAnimator.Play("TimerRed_AN");
    }
    void TimerAt3Minutes()
    {
        timerText.color = Color.yellow;
        timerTextAnimator.Play("TimerYellow_AN");
    }
    void GameOver()
    {

        if(remainingTime == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
