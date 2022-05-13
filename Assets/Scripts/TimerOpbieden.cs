using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerOpbieden : MonoBehaviour
{
    [SerializeField][Range(0, 30)] private int TimeInMinutes = 5;

    private TextMeshProUGUI timerTarget;
    private float time;

    private bool stop = false;

    public void Start()
    {
        timerTarget = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();

        time = Time.time;
    }

    private void Update()
    {
        if (Time.time >= time + 1f && TimeInMinutes > 0 && !stop)
        {
            TimeInMinutes--;
            time = Time.time;
            Debug.Log(TimeInMinutes);
        }
        if(TimeInMinutes <= 0f)
        {
            GameObject.Find("BidButton").GetComponent<Button>().interactable = false;
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
