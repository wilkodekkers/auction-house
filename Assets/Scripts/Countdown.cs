using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;

    private void Start()
    {
        timerIsRunning = true;
    }

    private void Update()
    {
        if (timerIsRunning || timeRemaining < 1)
        {
            timeRemaining = 0;
            timerIsRunning = false;
        }

        timeRemaining -= Time.deltaTime;
        DisplayTime(timeRemaining);
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float Minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float Seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = $"{Minutes:00}:{Seconds:00}";
    }
}