using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class AuctionService : MonoBehaviour
{
    private const string URL = "https://localhost:7254/api/auctionhouse/auctions";
    private List<Auction> auctions = new List<Auction>();

    private void Start()
    {
        StartCoroutine(GetAuctions());
    }

    private IEnumerator GetAuctions()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
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
