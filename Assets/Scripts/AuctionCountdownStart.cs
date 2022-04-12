using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AuctionCountdownStart : MonoBehaviour
{
    [SerializeField][Range(0, 120)] private int timeInSeconds = 60;

    private float timer;
    private Button auctionStartButton;
    private TextMeshProUGUI buttonText;

    void Start()
    {
        timer = Time.time;
        auctionStartButton = GameObject.Find("ButtonAuctionStart").GetComponent<Button>();
        buttonText = auctionStartButton.GetComponentInChildren<TextMeshProUGUI>();

        auctionStartButton.onClick.AddListener(() => SceneManager.LoadScene("BidGame"));
    }

    void Update()
    {
        if (Time.time >= timer + 1f && timeInSeconds > 0)
        {
            timeInSeconds--;
            timer = Time.time;
        }

        if (timeInSeconds <= 0 && auctionStartButton.interactable == false)
        {
            buttonText.SetText("Start auction");
            auctionStartButton.interactable = true;
        }
    }

    private void FixedUpdate()
    {
        if (timeInSeconds > 0)
        {
            buttonText.SetText("Auction starts in: " + timeInSeconds.ToString());
        }
    }
}
