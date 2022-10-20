using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    /// <summary>
    /// class to create product bids and purchases
    /// </summary>
    public class Bid : Product
    {
        public AccountId BidderAccountId { get; }
        public string BidPrice { get; }
        public string Delivery { get; }
        public Bid(AccountId accountId, int id, string name, string desc, string price, AccountId bidderAccountId, string bidPrice, string delivery) : base(accountId, id, name, desc, price)
        {
            BidderAccountId = bidderAccountId;
            BidPrice = bidPrice;
            Delivery = delivery;
        }
        //method that returns the string value of the bid or purchase
        public override string ToString()
        {
            return $"{AccountId}\t{ProductId}\t{Name}\t{Description}\t{Price}\t{BidderAccountId}\t{BidPrice}\t{Delivery}";
        }
        //method that checks if the bidder id matches the supplied account id
        public bool BidderIdMatches(AccountId accountId) { return this.BidderAccountId.Equals(accountId); }
    }
}
