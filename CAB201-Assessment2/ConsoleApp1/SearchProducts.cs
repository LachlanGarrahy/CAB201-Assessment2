using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SearchProducts: Dialog
    {
        private AccountHolder holder;

        private List<Product> products = new List<Product>();
        private static string itemDialog = "Item #\tProduct name\tDescription\tList Price\tBidder name\tBidder email\tBid amt";
        private string searchTerm;
        public SearchProducts(AccountHolder holder, string title, AuctionHouse house) : base(title, house)
        {
            this.holder = holder;
        }

        public override void Display()
        {
            Console.WriteLine($"\n{Title}");

            searchTerm = getSearchTerm();

            if (searchTerm == "ALL") products = AuctionHouse.GetAllProducts();
            else products = AuctionHouse.GetSearchProducts(searchTerm);

            writeProducts();
        }

        private string getSearchTerm()
        {
            while (true)
            {
                Console.WriteLine("Please supply a search phrase (ALL to see all products)");

                searchTerm = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    break;
                }
            }
            return searchTerm;
        }

        private void writeProducts()
        {
            Console.WriteLine("Search results\n--------------");
            Console.WriteLine(itemDialog);
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i+1}\t{products[i].Name}\t{products[i].Description}\t{products[i].Price}");
            }
        }
    }
}
