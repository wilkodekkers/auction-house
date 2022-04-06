using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerCountDown : MonoBehaviour
{
    [SerializeField][Range(0, 30)] private int TimeInMinutes = 5;
    private TextMeshProUGUI target;
    private float time;

    private void Start()
    {
        target = FindObjectOfType<TextMeshProUGUI>();
        time = Time.time;
    }

    private void Update()
    {
        if (Time.time >= time + 1f && TimeInMinutes > 0)
        {
            TimeInMinutes--;
            time = Time.time;
        }
    }

    private void FixedUpdate()
    {
        if (int.Parse(target.text) != TimeInMinutes)
        {
            target.SetText(TimeInMinutes.ToString());
        }
    }
}
