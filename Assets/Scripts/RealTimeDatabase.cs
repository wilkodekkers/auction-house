using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class RealTimeDatabase : MonoBehaviour
{
    private float _startPrice;
    public string WinningPlayerName { get; private set; }
    private readonly List<GameObject> _characters = new();
    private Button _priceButton;
    private Button _bidButton;
    private Button _winningPlayer;
    private DatabaseReference _reference;

    [SerializeField] private Transform objectToLookAt;
    [SerializeField] private GameObject playerModel;

    private void Start()
    {
        _reference = FirebaseDatabase.DefaultInstance.RootReference;

        _bidButton = GameObject.Find("BidButton").GetComponent<Button>();
        _priceButton = GameObject.Find("PriceButton").GetComponent<Button>();
        _winningPlayer = GameObject.Find("winningPlayer").GetComponent<Button>();

        InitializeCharacters();

        _bidButton.onClick.AddListener(PriceUp);
        _reference.Child("TestData").Child("data").Child("Bid").ValueChanged += HandleValuePriceChanged;
        _reference.Child("TestData").Child("data").Child("Email").ValueChanged += HandleNameValueChanged;
    }

    private void InitializeCharacters()
    {
        // Find all stools in the scene
        var Spawns = GameObject.FindGameObjectsWithTag("Stool");

        foreach (var Stool in Spawns)
        {
            // Put a character on each stool
            var Character = Instantiate(playerModel);
            Character.transform.position = Stool.transform.position + new Vector3(0.0f, 0.6f, 0.0f);
            _characters.Add(Character);
        }
    }

    private void PriceUp()
    {
        _reference.Child("TestData").Child("data").Child("Bid").SetValueAsync(_startPrice + 1000);
        _reference.Child("TestData").Child("data").Child("Email").SetValueAsync(PlayerPrefs.GetString("email"));
    }

    private void HandleValuePriceChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        _startPrice = float.Parse(args.Snapshot.Value.ToString());
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
        _priceButton.GetComponentInChildren<TextMeshProUGUI>().SetText(_startPrice.ToString());
        _winningPlayer.GetComponentInChildren<TextMeshProUGUI>().SetText(WinningPlayerName);

        // Let all characters look at the moving object in the scene
        foreach (var Character in _characters)
        {
            Character.transform.LookAt(objectToLookAt);
        }
    }
}