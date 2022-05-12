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

        reference.Child("TestData").Child("data").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                StartPrice = float.Parse(snapshot.Child("Bid").Value.ToString());
            }
        });


        button = GameObject.Find("BidButton").GetComponent<Button>();
        priceButton = GameObject.Find("PriceButton").GetComponent<Button>();

        button.onClick.AddListener(PriceUp);
    }

    private void PriceUp()
    {
        reference.Child("TestData").Child("data").Child("Bid").SetValueAsync(StartPrice + 1000);

        reference.Child("TestData").Child("data").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                StartPrice = float.Parse(snapshot.Child("Bid").Value.ToString());
            }
        });
    }

    private void FixedUpdate()
    {
        priceButton.GetComponentInChildren<TextMeshProUGUI>().SetText(StartPrice.ToString());
    }
}
