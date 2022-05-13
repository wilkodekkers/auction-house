using System;
using UnityEngine;

public class Auction
{
    public string id { get; set; }
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
    public AuctionType auctiontype { get; set; }
}