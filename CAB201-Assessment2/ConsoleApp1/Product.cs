using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// class to create the product object and check whether the information matches
    /// </summary>
    public class Product
    {
        public AccountId AccountId { get; }
        public int ProductId { get; }
        public string Name { get; }
        public string Description { get; }
        public string Price { get; }

        public Product(AccountId accountId, int id, string name, string desc, string price)
        {
            AccountId = accountId;
            ProductId = id;
            Name = name;
            Description = desc;
            Price = price;
        }
        //methods to check whether the information matches
        public bool AccountIdMatches(AccountId accountId) { return this.AccountId.Equals(accountId); }

        public bool ProductIdMatches(int id) { return this.ProductId.Equals(id); }

        public bool ProductNameMatches(string name) { return this.Name.Equals(name); }
    }
}
