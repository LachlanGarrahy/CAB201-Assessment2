using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ProductDisplay: Dialog
    {
        private ProductBid bid;

        private const string itemDialog = "\nItem #\tProduct name\tDescription\tList Price\tBidder name\tBidder email\tBid amt",
            bidDataNull = "-\t-\t-";

        private string bidderName, bidData;
        public ProductDisplay(string title, AuctionHouse house) : base(title, house)
        {
        }

        public void DisplayProducts(List<ProductListing> products)
        {
            Console.WriteLine(itemDialog);

            for (int i = 0; i < products.Count; i++)
            {
                bid = getBid(products[i].ProductId);
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

        public void DisplayNoResultError(string errorMessage)
        {
            Console.WriteLine($"\n\t{errorMessage}");
        }

        private ProductBid getBid(int prodId)
        {
            return AuctionHouse.GetProductBids(prodId);
        }

        public List<ProductListing> SortProductList(List<ProductListing> productsToSort)
        {
            productsToSort.OrderBy(x => x.Name)
                .ThenBy(x => x.Description)
                .ThenBy(x => x.Price)
                .ToList();

            return productsToSort;
        }
    }
}
