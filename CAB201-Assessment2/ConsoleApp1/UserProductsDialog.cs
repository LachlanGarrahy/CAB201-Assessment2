using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class UserProductsDialog: ProductDisplay
    {

        private AccountHolder holder;

        private List<ProductListing> products = new List<ProductListing>();
        public UserProductsDialog(AccountHolder holder, string title, AuctionHouse house) : base(title, house)
        {
            this.holder = holder;
        }

        public override void Display()
        {
            Console.WriteLine($"\n{Title}");

            products = AuctionHouse.GetUserProducts(holder.AccountId);

            DisplayProducts(products);
        }
    }
}
