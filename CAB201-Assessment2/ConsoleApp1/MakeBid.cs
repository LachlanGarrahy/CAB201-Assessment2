using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ConsoleApp1
{
    internal class MakeBid
    {
        private AccountHolder holder;
        private AuctionHouse house;
        private List<ProductListing> products = new List<ProductListing>();
        private Product item;
        private ProductBid bid;

        private const string SEARCHPROMPT = "\nwould you like to place a bid on any of these items (yes or no)?";
        private const string BIDPROMPT = "\nHow much do you bid?";
        private const string DELIVERYTITLE = "\nDelivery Instructions\n--------------------";

        const string CLICKCOL = "Click and Collect",
            HOMEDEL = "Home Delivery";

        const uint CLICKCOL_OPT = 1,
            HOMEDEL_OPT = 2;

        private string searchTerm;
        private int itemNumber = 0;
        private string bidPrice = "$0.00";
        private string currentBid;
        private decimal existingBidDecimal;
        private decimal currentBidDecimal;
        private string deliveryOption;

        public MakeBid(AccountHolder holder, AuctionHouse house, List<ProductListing> products)
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
            if (bid != null) bidPrice = bid.BidPrice;
            Console.WriteLine($"\nBidding for {item.Name} (regular price {item.Price}), current highest bid {bidPrice}");

            while (true)
            {
                currentBid = Util.getString(BIDPROMPT);
                if (validBidEntry(currentBid)) break;
            }

            Console.WriteLine($"\nYour bid of {currentBid} for {item.Name} is placed.");

            Console.WriteLine(DELIVERYTITLE);
            uint option = Util.ReadUint(CLICKCOL, HOMEDEL);

            Process(option);


            if (bid == null) house.CreateBid(item.AccountId, item.Name, item.Description, item.Price, holder.AccountId, currentBid, deliveryOption);
            else house.UpdateBid(item.AccountId, item.Name, item.Description, item.Price, holder.AccountId, currentBid, deliveryOption);
        }

        private void Process(uint option)
        {
            switch (option)
            {
                case CLICKCOL_OPT:
                    clickAndCollect();
                    break;
                case HOMEDEL_OPT:
                    homeDelivery();
                    break;
                default:
                    // do nothing.
                    break;
            }
        }

        private void clickAndCollect()
        {
            deliveryOption = "remote";
        }

        private void homeDelivery()
        {
            deliveryOption = "home";
            bool registered = getRegistered();
            if (registered)
            {
                UserAddress address = house.GetUserAddress(holder.AccountId);
                house.RegisterDeliveryAddress(item.Name, address.UnitNo, address.StNo, address.StName, address.Suffix, address.City, address.State, address.Postcode);

                if (address.UnitNo == 0) Console.WriteLine($"\nThank you for your bid. If successful, the item will be provided via delivery to {address.StNo} {address.StName} {address.Suffix}, {address.City} {address.State} {address.Postcode}");
                else Console.WriteLine($"\nAddress has been updated to {address.UnitNo}/{address.StNo} {address.tName} {suffix}, {city} {state} {postcode}");
            }
            else
            {
                AddressDialog registerAddress = new AddressDialog(holder, house);
                registerAddress.createDeliveryAddress(item.Name);
            }
            Console.WriteLine("Thank you for your bid. If successful, the item will be provided via delivery to ")
            if (unitNo == 0) Console.WriteLine($"\nAddress has been updated to {stNo} {stName} {suffix}, {city} {state} {postcode}");
            else Console.WriteLine($"\nAddress has been updated to {unitNo}/{stNo} {stName} {suffix}, {city} {state} {postcode}");
        }

        private bool getRegistered()
        {
            Console.WriteLine("Would you like to use your registered address?");
            Console.Write("> ");
            string answer = Console.ReadLine();
            if (answer == "yes") return true;
            return false;
        }

        private Product getProductInfo(int item)
        {
            return products[item-1];
        }
        

        private ProductBid getBid(string name)
        {
            return house.GetProductBids(name);
        }

        private bool validBidEntry(string bidString)
        {
            if (!bidIsBid(bidString)) return false;
            if (!isBidBigger(bidString))  return false;
            return true;
        }

        private bool bidIsBid(string bidString)
        {
            return true;
        }

        private bool isBidBigger(string bidString)
        {
            existingBidDecimal = decimal.Parse(bidPrice, NumberStyles.Currency);
            currentBidDecimal = decimal.Parse(bidString, NumberStyles.Currency);
            if (existingBidDecimal >= currentBidDecimal)
            {
                Console.WriteLine("Please enter an amount higher than the current bid");
                return false;
            }
            return true;
        }
    }
}
