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
        private const string itemDialog = "\nItem #\tProduct name\tDescription\tList Price\tBidder name\tBidder email\tBid amt";
        private string bidderName;
        private const string bidDataNull = "-\t-\t-";
        private string bidData;
        public ProductDisplay(string title, AuctionHouse house) : base(title, house)
        {
        }

        public void DisplayProducts(List<ProductListing> products)
        {
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

        public List<ProductListing> SortProductList(List<ProductListing> productsToSort)
        {
            productsToSort.Sort(delegate (ProductListing x, ProductListing y)
            {
                return x.Name.CompareTo(y.Name);
            });

            return productsToSort;
        }
    }
}
