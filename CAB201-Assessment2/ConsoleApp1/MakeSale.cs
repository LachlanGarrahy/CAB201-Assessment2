using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// method to create the sale object
    /// </summary>
    internal class MakeSale
    {
        private AuctionHouse house;
        private List<ProductListing> products = new List<ProductListing>();
        private Product item;
        private ProductBid bid;
        private string bidderName;

        private const string SEARCHPROMPT = "\nwould you like to sell something (yes or no)?",
            OUTOFBOUNDSERROR = "\n\tValue must be between 1 and {0}";

        private string searchTerm;
        private int itemNumber = 0;

        public MakeSale(AuctionHouse house, List<ProductListing> products)
        {
            this.house = house;
            this.products = products;
        }
        //method to get relevant information
        public void Display()
        {
            searchTerm = Util.getString(SEARCHPROMPT);
            if (searchTerm != "yes") return;

            getItemNumber();

            item = getProductInfo(itemNumber);
            bid = getBid(item.ProductId);
            bidderName = getBidderName(bid.BidderAccountId);

            Console.WriteLine($"\nYou have sold {bid.Name} to {bidderName} for {bid.BidPrice}.");

            house.CreateSale(bid.AccountId, bid.ProductId, bid.Name, bid.Description, bid.Price, bid.BidderAccountId, bid.BidPrice, bid.Delivery);
        }
        //method to get the relevant information
        private void getItemNumber()
        {
            string itemPropmt = $"\nPlease enter a non-negative integer between 1 and {products.Count()}:";
            while (true)
            {
                itemNumber = Util.getNumber(itemPropmt);
                if (itemNumber > 0 & itemNumber <= products.Count()) break;
                Console.WriteLine(OUTOFBOUNDSERROR, products.Count());
            }
        }
        private Product getProductInfo(int item)
        {
            return products[item - 1];
        }

        private ProductBid getBid(int productId)
        {
            return house.GetProductBids(productId);
        }     
        
        private string getBidderName(AccountId id)
        {
            return house.GetAccountId(id).Name;
        }
    }
}
