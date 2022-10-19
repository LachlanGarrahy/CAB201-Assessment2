using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ProductListing: Product
    {
        public ProductListing(AccountId accountId, string name, string desc, string price) : base(accountId, name, desc, price)
        {
        }

        public override string ToString()
        {
            return $"{AccountId},{Name},{Description},{Price}";
        }
    }
}
