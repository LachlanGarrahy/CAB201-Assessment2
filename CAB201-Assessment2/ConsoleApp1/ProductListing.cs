using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// class to instantiate product listings
    /// </summary>
    public class ProductListing: Product
    {
        public ProductListing(AccountId accountId, int id, string name, string desc, string price) : base(accountId, id, name, desc, price)
        {
        }

        public override string ToString()
        {
            return $"{AccountId}\t{ProductId}\t{Name}\t{Description}\t{Price}";
        }
    }
}
