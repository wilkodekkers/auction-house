using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float timeRemaning = 10;
    public bool timerisRunning = false;
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        timerisRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerisRunning)
        {
            if (timeRemaning > 0)
            {
                timeRemaning -= Time.deltaTime;
                DisplayTime(timeRemaning);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaning = 0;
                timerisRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}


