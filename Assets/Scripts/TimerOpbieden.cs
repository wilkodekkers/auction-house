using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerOpbieden : MonoBehaviour
{
    private int TimeInSeconds;
    private TextMeshProUGUI timerTarget;
    private float time;
    private bool stop = false;
    private DateTime currentTime;
    private DateTime auctionStopTime;

    private RealTimeDatabase RealTimeDatabase { get; set; }

    public void Start()
    {
        currentTime = DateTime.Now;
        //Needs to change to DateTime from database
        auctionStopTime = currentTime.AddSeconds(7);
        //Calculates how long until auction ends
        TimeInSeconds = (int)(auctionStopTime - currentTime).TotalSeconds;

        Screen.orientation = ScreenOrientation.LandscapeLeft;

        timerTarget = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();

        time = Time.time;

        RealTimeDatabase = FindObjectOfType<RealTimeDatabase>();
    }

    private void Update()
    {
        if (Time.time >= time + 1f && TimeInSeconds > 0 && !stop)
        {
            TimeInSeconds--;
            time = Time.time;
            Debug.Log(TimeInSeconds);
        }
        else if (TimeInSeconds <= 0f)
        {
            GameObject.Find("BidButton").GetComponent<Button>().interactable = false;
            CheckWinner();
        }
    }

    private void CheckWinner()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        var email = PlayerPrefs.GetString("email");
        if (RealTimeDatabase.WinningPlayerName == email)
        {
            SceneManager.LoadScene("Product_Won");
        }
        else
        {
            SceneManager.LoadScene("upcoming_auctions");
        }
    }

    private void FixedUpdate()
    {
        if (int.Parse(timerTarget.text) != TimeInSeconds)
        {
            timerTarget.SetText(TimeInSeconds.ToString());
        }
    }
}
