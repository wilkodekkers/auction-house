using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;
using TMPro;

public class database_test : MonoBehaviour
{
    private float StartPrice ;
    private Button priceButton;

    private Button button;

    DatabaseReference reference;

    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        button = GameObject.Find("BidButton").GetComponent<Button>();
        priceButton = GameObject.Find("PriceButton").GetComponent<Button>();

        button.onClick.AddListener(PriceUp);
        reference.Child("TestData").Child("data").Child("Bid").ValueChanged += HandleValueChanged;
    }

    private void PriceUp()
    {
        reference.Child("TestData").Child("data").Child("Bid").SetValueAsync(StartPrice + 1000);

    }

    private void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        StartPrice = float.Parse(args.Snapshot.Value.ToString());
    }

    private void FixedUpdate()
    {
        priceButton.GetComponentInChildren<TextMeshProUGUI>().SetText(StartPrice.ToString());
    }
}
