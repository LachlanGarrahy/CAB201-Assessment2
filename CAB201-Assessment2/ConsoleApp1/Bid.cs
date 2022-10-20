using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class Bid : Product
    {
        public AccountId BidderAccountId { get; }
        public string BidPrice { get; }
        public string Delivery { get; }
        public Bid(AccountId accountId, int id, string name, string desc, string price, AccountId bidderAccountId, string bidPrice, string delivery) : base(accountId, id, name, desc, price)
        {
            if (IsValid(bidPrice))
            {
                BidderAccountId = bidderAccountId;
                BidPrice = bidPrice;
                Delivery = delivery;
            }
            else
            {
                throw new ArgumentException("Product!");
            }
        }
        public static bool IsValid(string BidPrice)
        {

            return true;
        }

        public override string ToString()
        {
            return $"{AccountId}\t{ProductId}\t{Name}\t{Description}\t{Price}\t{BidderAccountId}\t{BidPrice}\t{Delivery}";
        }

        public bool BidderIdMatches(AccountId accountId) { return this.BidderAccountId.Equals(accountId); }
    }
}
