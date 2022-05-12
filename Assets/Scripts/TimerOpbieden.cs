using TMPro;
using UnityEngine;
using Firebase.Database;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerOpbieden : MonoBehaviour
{
    [SerializeField][Range(0, 30)] private int TimeInMinutes = 20;

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
