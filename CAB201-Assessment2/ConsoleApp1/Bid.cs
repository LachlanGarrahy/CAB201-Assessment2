using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Bid : Product
    {
        public AccountId BidderAccountId { get; }
        public string BidPrice { get; }
        public string Delivery { get; }
        public Bid(AccountId accountId, string name, string desc, string price, AccountId bidderAccountId, string bidPrice, string delivery) : base(accountId, name, desc, price)
        {
            if (IsValid(bidderAccountId, bidPrice))
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
        public static bool IsValid(AccountId BidderAccountId, string BidPrice)
        {
            return true;
        }

        public override string ToString()
        {
            return $"{Name},{BidderAccountId},{BidPrice},{Delivery}";
        }

        public bool BidderIdMatches(AccountId accountId) { return this.BidderAccountId.Equals(accountId); }
    }
}
