using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// class to instantiate product purchases
    /// </summary>
    public class ProductPurchase: Bid
    {
        public ProductPurchase(AccountId accountId, int id, string name, string desc, string price, AccountId bidderAccountId, string bidPrice, string delivery) : base(accountId, id, name, desc, price, bidderAccountId, bidPrice, delivery)
        {
        }
    }
}
