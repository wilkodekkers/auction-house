using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;
using TMPro;

public class RealTimeDatabase : MonoBehaviour
{
    private float StartPrice;
    private string winningPlayerName;

    private Button priceButton;
    private Button bidButton;
    private Button winningPlayer;

    DatabaseReference reference;

    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        bidButton = GameObject.Find("BidButton").GetComponent<Button>();
        priceButton = GameObject.Find("PriceButton").GetComponent<Button>();
        winningPlayer = GameObject.Find("winningPlayer").GetComponent<Button>();

        bidButton.onClick.AddListener(PriceUp);
        reference.Child("TestData").Child("data").Child("Bid").ValueChanged += HandleValuePriceChanged;
        reference.Child("TestData").Child("data").Child("Email").ValueChanged += HandleNameValueChanged;
    }

    private void PriceUp()
    {
        winningPlayerName = PlayerInfo.email;

        reference.Child("TestData").Child("data").Child("Bid").SetValueAsync(StartPrice + 1000);
        reference.Child("TestData").Child("data").Child("Email").SetValueAsync(winningPlayerName);
        Debug.Log(reference.Child("TestData").Child("data").Child("Email").ToString());

    }

    private void HandleValuePriceChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        StartPrice = float.Parse(args.Snapshot.Value.ToString());
    }

    private void HandleNameValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        winningPlayerName = args.Snapshot.Value.ToString();
    }

    private void FixedUpdate()
    {
        priceButton.GetComponentInChildren<TextMeshProUGUI>().SetText(StartPrice.ToString());
        winningPlayer.GetComponentInChildren<TextMeshProUGUI>().SetText(winningPlayerName);
    }
}
