using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class UserProductsDialog: Dialog
    {

        private AccountHolder holder;

        private List<ProductListing> products = new List<ProductListing>();
        private static string itemDialog = "Item #\tProduct name\tDescription\tList Price\tBidder name\tBidder email\tBid amt";
        public UserProductsDialog(AccountHolder holder, string title, AuctionHouse house) : base(title, house)
        {
            this.holder = holder;
        }

        public override void Display()
        {
            Console.WriteLine($"\n{Title}");

            products = AuctionHouse.GetUserProducts(holder.AccountId);
            writeProducts();
        }

        private void writeProducts()
        {
            Console.WriteLine(itemDialog);
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i+1}\t{products[i].Name}\t{products[i].Description}\t{products[i].Price}");
            }
        }
        
    }
}
