using UnityEngine;
using TMPro;
using System;
public class Timer : MonoBehaviour
// this script will set a timer that will track the time of the player in the game. the timer will start when the game starts, and end when the player reaches the end of the game.
// the final time will be displayed on screen when the player reaches the end.
{

    private bool isTimerRunning = false;
    private float currentTime = 0f;
    public TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component for displaying the timer

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = 0f;
        isTimerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            currentTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }
    void UpdateTimerDisplay()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
        timerText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
    }
}
