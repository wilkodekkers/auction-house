using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerCountDown : MonoBehaviour
{
    [SerializeField][Range(0, 30)] private int TimeInMinutes = 5;
    private TextMeshProUGUI target;
    private float time;

    private bool stop = false;
    private Button button;

    private void Start()
    {
        target = FindObjectOfType<TextMeshProUGUI>();
        button = FindObjectOfType<Button>();

        time = Time.time;
        button.onClick.AddListener(OnButtonClick);
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
        if (int.Parse(target.text) != TimeInMinutes)
        {
            target.SetText(TimeInMinutes.ToString());
        }
    }

    private void OnButtonClick()
    {
        stop = true;
    }
}
