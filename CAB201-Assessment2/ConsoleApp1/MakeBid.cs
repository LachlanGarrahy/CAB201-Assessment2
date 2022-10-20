using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ConsoleApp1
{
    /// <summary>
    /// method to allow the user to create a bid
    /// </summary>
    internal class MakeBid
    {
        private AccountHolder holder;
        private AuctionHouse house;
        private List<ProductListing> products = new List<ProductListing>();
        private Product item;
        private ProductBid bid;

        private const string SEARCHPROMPT = "\nwould you like to place a bid on any of these items (yes or no)?",
            BIDPROMPT = "\nHow much do you bid?",
            DELIVERYTITLE = "\nDelivery Instructions\n--------------------",
            BIDERROR = "\n\tPlease enter an amount higher than the current bid",
            CLICKCOL = "Click and Collect",
            HOMEDEL = "Home Delivery",
            OUTOFBOUNDSERROR = "\n\tValue must be between 1 and {0}";

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
        //method to get all fields and create the bid item
        public void Display()
        {
            searchTerm = Util.getString(SEARCHPROMPT);
            if (searchTerm != "yes") return;

            GetItem();

            getNewBid();

            Console.WriteLine($"\nYour bid of {currentBid} for {item.Name} is placed.");

            Console.WriteLine(DELIVERYTITLE);
            uint option = Util.ReadUint(CLICKCOL, HOMEDEL);

            Process(option);

            if (bid == null) house.CreateBid(item.AccountId, item.ProductId, item.Name, item.Description, item.Price, holder.AccountId, currentBid, deliveryOption);
            else house.UpdateBid(item.AccountId, item.ProductId, item.Name, item.Description, item.Price, holder.AccountId, currentBid, deliveryOption);
        }
        //method to get the item the user wishes to make a bid on
        private void GetItem()
        {
            string itemPropmt = $"\nPlease enter a non-negative integer between 1 and {products.Count()}:";

            while (true)
            {
                itemNumber = Util.getNumber(itemPropmt);
                if (itemNumber > 0 & itemNumber <= products.Count()) break;
                Console.WriteLine(OUTOFBOUNDSERROR, products.Count());
            }

            item = getProductInfo(itemNumber);
            bid = getBid(item.ProductId);

            if (bid != null) bidPrice = bid.BidPrice;
            Console.WriteLine($"\nBidding for {item.Name} (regular price {item.Price}), current highest bid {bidPrice}");
        }
        //method to get the bid
        private void getNewBid()
        {
            while (true)
            {
                currentBid = Util.getPrice(BIDPROMPT);
                if (isBidBigger(currentBid)) break;
            }
        }
        //method to process the user option
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
        //method to get click and collect times
        private void clickAndCollect()
        {
            deliveryOption = "clickcol";
            ClickColDialog clickCol = new ClickColDialog(house);
            clickCol.getClickColTimes(item.ProductId);
        }
        //method to get delivery information
        private void homeDelivery()
        {
            deliveryOption = "delivery";
            bool registered = getRegistered();
            getDeliveryAddressInfo(registered);
        }
        //method to prompt the user call the methods to input their data
        private void getDeliveryAddressInfo(bool registered)
        {
            if (registered)
            {
                UserAddress address = house.GetUserAddress(holder.AccountId);
                house.RegisterDeliveryAddress(item.ProductId, address.UnitNo, address.StNo, address.StName, address.Suffix, address.City, address.State, address.Postcode);

                if (address.UnitNo == 0) Console.WriteLine($"\nThank you for your bid. If successful, the item will be provided via delivery to {address.StNo} {address.StName} {address.Suffix}, {address.City} {address.State} {address.Postcode}");
                else Console.WriteLine($"\nThank you for your bid. If successful, the item will be provided via delivery to {address.UnitNo}/{address.StNo} {address.StName} {address.Suffix}, {address.City} {address.State} {address.Postcode}");
            }
            else
            {
                AddressDialog registerAddress = new AddressDialog(holder, house);
                registerAddress.createDeliveryAddress(item.ProductId);
            }
        }
        //method to ask the user if they wish to use their registered address
        private bool getRegistered()
        {
            Console.WriteLine("Would you like to use your registered address?");
            Console.Write("> ");
            string answer = Console.ReadLine();
            if (answer == "yes") return true;
            return false;
        }
        //method to get the product the user selected
        private Product getProductInfo(int item)
        {
            return products[item-1];
        }
        //method to get the user bid
        private ProductBid getBid(int productId)
        {
            return house.GetProductBids(productId);
        }
        //method to check whether the bid is bigger than the current bid
        private bool isBidBigger(string bidString)
        {
            existingBidDecimal = decimal.Parse(bidPrice, NumberStyles.Currency);
            currentBidDecimal = decimal.Parse(bidString, NumberStyles.Currency);
            if (existingBidDecimal >= currentBidDecimal)
            {
                Console.WriteLine(BIDERROR);
                return false;
            }
            return true;
        }
    }
}
