using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class AuctionService : MonoBehaviour
{
    private const string BASE_ENDPOINT = "https://localhost:7254/api/auctionhouse";
    private List<Auction> auctions = new List<Auction>();

    [SerializeField] private GameObject buttonTemplate;

    private void Start()
    {
        StartCoroutine(GetAuctions());
    }

    private IEnumerator GetAuctions()
    {
        using (UnityWebRequest request = UnityWebRequest.Get($"{BASE_ENDPOINT}/auctions"))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                auctions = JsonConvert.DeserializeObject<List<Auction>>(request.downloadHandler.text);
                GameObject g;
                for (int i = 0; i < auctions.Count; i++) {
                    var auction = auctions[i];
                    g = Instantiate(buttonTemplate, transform);
                    g.name = $"item {i}";
                    GameObject.Find($"{g.name}/title").GetComponent<TextMeshProUGUI>().text = "Auction";
                    GameObject.Find($"{g.name}/description").GetComponent<TextMeshProUGUI>().text = $"{auction.startTime.ToString("dd-MM-yyyy")} \t\t\t {auction.startTime.ToString("HH:mm")} - {auction.endTime.ToString("HH:mm")}";
                }
            }
        }
    }
}
