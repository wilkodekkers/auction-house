using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerOpbieden : MonoBehaviour
{
    [SerializeField][Range(0, 30)] private int TimeInMinutes = 5;

    private TextMeshProUGUI timerTarget;
    private float time;

    private bool stop = false;

    private RealTimeDatabase RealTimeDatabase { get; set; }

    public void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        timerTarget = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();

        time = Time.time;

        RealTimeDatabase = FindObjectOfType<RealTimeDatabase>();
    }

    private void Update()
    {
        if (Time.time >= time + 1f && TimeInMinutes > 0 && !stop)
        {
            TimeInMinutes--;
            time = Time.time;
            Debug.Log(TimeInMinutes);
        }
        else if (TimeInMinutes <= 0f)
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
        if (int.Parse(timerTarget.text) != TimeInMinutes)
        {
            timerTarget.SetText(TimeInMinutes.ToString());
        }
    }
}
