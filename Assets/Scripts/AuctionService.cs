using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class AuctionService : MonoBehaviour
{
    private const string BASE_ENDPOINT = "https://localhost:7254/api/auctionhouse";
    private List<Auction> auctions = new List<Auction>();

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
                Debug.Log($"({auctions.Count}) Auctions fetched");
            }
        }
    }
}
