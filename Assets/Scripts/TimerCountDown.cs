using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerCountDown : MonoBehaviour
{
    [SerializeField][Range(0, 30)] private int TimeInMinutes = 5;
    [SerializeField][Range(0, 100000)] private float StartPrice = 69420F;

    private TextMeshProUGUI timerTarget;
    private Button priceButton;
    private float time;

    private bool stop = false;
    private Button button;

    private void Start()
    {
        timerTarget = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
        button = GameObject.Find("BidButton").GetComponent<Button>();
        priceButton = GameObject.Find("PriceButton").GetComponent<Button>();

        time = Time.time;
        button.onClick.AddListener(() => stop = true);
    }

    private void Update()
    {
        if (Time.time >= time + 1f && TimeInMinutes > 0 && !stop)
        {
            TimeInMinutes--;
            StartPrice *= 0.98f;
            time = Time.time;
        }
    }

    private void FixedUpdate()
    {
        if (int.Parse(timerTarget.text) != TimeInMinutes)
        {
            timerTarget.SetText(TimeInMinutes.ToString());
            priceButton.GetComponentInChildren<TextMeshProUGUI>().SetText(StartPrice.ToString());
        }
    }
}
