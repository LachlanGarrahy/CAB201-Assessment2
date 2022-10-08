using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Product
    {
        public Product(AccountId accountId, string name, string desc, string price)
        {
            if (IsValid(accountId, name, desc, price))
            {
                AccountId = accountId;
                Name = name;
                Description = desc;
                Price = price;
            }
            else
            {
                throw new ArgumentException("Product!");
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

        public string Description
        {
            get;
        }
        public string Price
        {
            get;
        }

        public static bool IsValid(AccountId accountId, string name, string desc, string price)
        {
            return true;
        }

        public override string ToString()
        {
            return $"{AccountId},{Name},{Description},{Price}";
        }

        public bool AccountIdMatches(AccountId accountId) { return this.AccountId.Equals(accountId); }

        public bool ProductNameMatches(string name) { return this.Name.Equals(name); }
    }
}
