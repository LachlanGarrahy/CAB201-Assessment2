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

        private const string errorMessage = "No items could be found";
        public UserProductsDialog(AccountHolder holder, string title, AuctionHouse house) : base(title, house)
        {
            this.holder = holder;
        }

        public override void Display()
        {
            Console.WriteLine($"\n{Title}");

            products = AuctionHouse.GetUserProducts(holder.AccountId);

            if (!(products.Count > 0))
            {
                DisplayNoResultError(errorMessage);
                return;
            }

            products = SortProductList(products);

            DisplayProducts(products);
        }
    }
}
