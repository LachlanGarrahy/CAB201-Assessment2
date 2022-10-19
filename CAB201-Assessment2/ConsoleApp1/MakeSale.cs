using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MakeSale
    {
        private AccountHolder holder;
        private AuctionHouse house;
        private List<ProductListing> products = new List<ProductListing>();
        private Product item;
        private ProductBid bid;
        private string bidderName;

        private const string SEARCHPROMPT = "\nwould you like to place a bid on any of these items (yes or no)?";

        const string CLICKCOL = "Click and Collect",
            HOMEDEL = "Home Delivery";

        private string searchTerm;
        private int itemNumber = 0;
        private string bidPrice = "$0.00";
        private string currentBid;
        private decimal existingBidDecimal;
        private decimal currentBidDecimal;
        private string deliveryOption;

        public MakeSale(AccountHolder holder, AuctionHouse house, List<ProductListing> products)
        {
            this.house = house;
            this.holder = holder;
            this.products = products;
        }

        public void Display()
        {
            searchTerm = Util.getString(SEARCHPROMPT);
            if (searchTerm != "yes") return;

            string itemPropmt = $"\nPlease enter a non-negative integer between 1 and {products.Count()}:";

            while (true)
            {
                itemNumber = Convert.ToInt32(Util.getNumber(itemPropmt));
                if (itemNumber > 0 & itemNumber <= products.Count()) break;
            }

            item = getProductInfo(itemNumber);
            bid = getBid(item.Name);
            bidderName = getBidderName(bid.BidderAccountId);

            Console.WriteLine($"\nYou have sold {bid.Name} to {bidderName} for {bid.BidPrice}.");

            house.CreateSale(bid.AccountId, bid.Name, bid.Description, bid.Price, bid.AccountId, bid.BidPrice, bid.Delivery);
        }

        private Product getProductInfo(int item)
        {
            return products[item - 1];
        }

        private ProductBid getBid(string name)
        {
            return house.GetProductBids(name);
        }     
        
        private string getBidderName(AccountId id)
        {
            return house.GetAccountId(id).Name;
        }
    }
}
