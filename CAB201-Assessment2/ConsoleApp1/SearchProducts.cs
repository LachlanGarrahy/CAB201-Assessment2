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

        private List<ProductListing> products = new List<ProductListing>();
        private ProductBid bid;
        private static string itemDialog = "Item #\tProduct name\tDescription\tList Price\tBidder name\tBidder email\tBid amt";
        private string searchTerm;
        private string bidderName;
        private string bidData = "-\t-\t-";
        public SearchProducts(AccountHolder holder, string title, AuctionHouse house) : base(title, house)
        {
            this.holder = holder;
        }

        public override void Display()
        {
            Console.WriteLine($"\n{Title}");

            searchTerm = Util.getSearchTerm();

            if (searchTerm == "ALL") products = AuctionHouse.GetAllProducts();
            else products = AuctionHouse.GetSearchProducts(searchTerm);

            writeProducts();
        }

        private void writeProducts()
        {
            Console.WriteLine("Search results\n--------------");
            Console.WriteLine(itemDialog);
            for (int i = 0; i < products.Count; i++)
            {
                bid = getBid(products[i].Name);
                if (bid != null)
                {
                    bidderName = AuctionHouse.GetAccountId(bid.BidderAccountId).Name;
                    bidData = $"{bidderName}\t{bid.BidderAccountId}\t{bid.BidPrice}";
                }

                Console.WriteLine($"{i + 1}\t{products[i].Name}\t{products[i].Description}\t{products[i].Price}\t{bidData}");
            }
        }

        private ProductBid getBid(string name)
        {
            return AuctionHouse.GetProductBids(name);
        }
    }
}
