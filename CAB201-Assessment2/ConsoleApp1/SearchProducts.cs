using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SearchProducts: Dialog
    {
        private List<ProductListing> products = new List<ProductListing>();
        private ProductBid bid;
        private const string itemDialog = "Item #\tProduct name\tDescription\tList Price\tBidder name\tBidder email\tBid amt";
        private const string searchPrompt = "Please supply a search phrase (ALL to see all products)";
        private string searchTerm;
        private string bidderName;
        private const string bidDataNull = "-\t-\t-";
        private string bidData;
        public SearchProducts(string title, AuctionHouse house) : base(title, house)
        {
        }

        public override void Display()
        {
            Console.WriteLine($"\n{Title}");

            searchTerm = Util.getString(searchPrompt);

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
                else
                {
                    bidData = bidDataNull;
                }

                Console.WriteLine($"{i + 1}\t{products[i].Name}\t{products[i].Description}\t{products[i].Price}\t{bidData}");
            }
        }

        private ProductBid getBid(string name)
        {
            return AuctionHouse.GetProductBids(name);
        }

        public List<ProductListing> getCurrentProductList()
        {
            return products;
        }
    }
}
