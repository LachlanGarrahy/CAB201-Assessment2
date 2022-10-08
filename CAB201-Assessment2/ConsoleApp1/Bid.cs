using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Bid
    {
        public Bid(string name, string bidderName, AccountId accountId, string price)
        {
            if (IsValid(accountId, name, bidderName, price))
            {
                AccountId = accountId;
                Name = name;
                BidderName = bidderName;
                Price = price;
            }
            else
            {
                throw new ArgumentException("Bid!");
            }
        }

        public AccountId AccountId
        {
            get;
        }
        public string Name
        {
            get;
        }

        public string BidderName
        {
            get;
        }
        public string Price
        {
            get;
        }

        public static bool IsValid(AccountId accountId, string name, string bidderName, string price)
        {
            return true;
        }

        public override string ToString()
        {
            return $"{Name},{BidderName},{AccountId},{Price}";
        }

        public bool AccountIdMatches(AccountId accountId) { return this.AccountId.Equals(accountId); }

        public bool ProductNameMatches(string name) { return this.Name.Equals(name); }
    }
}
