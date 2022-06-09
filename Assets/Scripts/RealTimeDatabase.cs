using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class RealTimeDatabase : MonoBehaviour
{
    private float StartPrice;
    public string WinningPlayerName { get; set; }
    private List<GameObject> characters = new List<GameObject>();
    private Button priceButton;
    private Button bidButton;
    private Button winningPlayer;

    [SerializeField] private Transform objectToLookAt;
    [SerializeField] private GameObject playerModel;

    DatabaseReference reference;

    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        bidButton = GameObject.Find("BidButton").GetComponent<Button>();
        priceButton = GameObject.Find("PriceButton").GetComponent<Button>();
        winningPlayer = GameObject.Find("winningPlayer").GetComponent<Button>();

        InitializeCharacters();

        bidButton.onClick.AddListener(PriceUp);
        reference.Child("TestData").Child("data").Child("Bid").ValueChanged += HandleValuePriceChanged;
        reference.Child("TestData").Child("data").Child("Email").ValueChanged += HandleNameValueChanged;
    }

    private void InitializeCharacters()
    {
        // Find all stools in the scene
        var spawns = GameObject.FindGameObjectsWithTag("Stool");

        foreach (var stool in spawns)
        {
            // Put a character on each stool
            GameObject character = Instantiate(playerModel);
            character.transform.position = stool.transform.position + new Vector3(0.0f, 0.6f, 0.0f);
            characters.Add(character);
        }
    }

    private void PriceUp()
    {
        WinningPlayerName = PlayerInfo.email;

        reference.Child("TestData").Child("data").Child("Bid").SetValueAsync(StartPrice + 1000);
        reference.Child("TestData").Child("data").Child("Email").SetValueAsync(WinningPlayerName);
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

        WinningPlayerName = args.Snapshot.Value.ToString();
    }

    private void FixedUpdate()
    {
        priceButton.GetComponentInChildren<TextMeshProUGUI>().SetText(StartPrice.ToString());
        winningPlayer.GetComponentInChildren<TextMeshProUGUI>().SetText(WinningPlayerName);

        // Let all characters look at the moving object in the scene
        foreach (var character in characters)
        {
            character.transform.LookAt(objectToLookAt);
        }
    }
}
