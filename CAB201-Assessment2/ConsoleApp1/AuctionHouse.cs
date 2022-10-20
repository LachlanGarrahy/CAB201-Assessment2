using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;



namespace ConsoleApp1
{
    /// <summary>
    /// class that stores all data relating to the auction house in runtime
    /// </summary>
    public class AuctionHouse
    {
        /// <summary>
        /// lists to hold the relevant data
        /// </summary>
        private List<AccountHolder> accountHolders = new List<AccountHolder>();
        private List<UserAddress> userAddresses = new List<UserAddress>();
        private List<ProductListing> products = new List<ProductListing>();
        private List<ProductBid> bids = new List<ProductBid>();
        private List<ProductPurchase> purchases = new List<ProductPurchase>();
        private List<DeliveryAddress> deliveryAddresses = new List<DeliveryAddress>();
        private List<ClickAndCollect> clickColTimes = new List<ClickAndCollect>();

        private int productId;


        public AuctionHouse()
        {
            // throw new System.NotImplementedException();
        }
        //methods to create relevant objects and save them to the relevant lists
        public void RegisterAccountHolder(AccountId accountId, string name, AccountPass accountPass)
        {
            accountHolders.Add(new AccountHolder(accountId, name, accountPass));
        }
        public void RegisterUserAddress(AccountId accountId, int unit, int stNo, string stName, string suffix, string city, string state, int postcode)
        {
            userAddresses.Add(new UserAddress(accountId, unit, stNo, stName, suffix, city, state, postcode));
        }
        public void RegisterExistingProduct(AccountId accountId, int prodId, string productName, string productDesc, string price)
        {
            products.Add(new ProductListing(accountId, prodId, productName, productDesc, price));
        }
        public void RegisterNewProduct(AccountId accountId, string productName, string productDesc, string price)
        {
            products.Add(new ProductListing(accountId, productId, productName, productDesc, price));
            increaseProductId();
        }
        public void CreateBid(AccountId accountId, int prodId, string productName, string productDesc, string price, AccountId bidderId, string bidPrice, string delivery)
        {
            bids.Add(new ProductBid(accountId, prodId, productName, productDesc, price, bidderId, bidPrice, delivery));
        }
        public void RegisterDeliveryAddress(int prodId, int unit, int stNo, string stName, string suffix, string city, string state, int postcode)
        {
            deliveryAddresses.Add(new DeliveryAddress(prodId, unit, stNo, stName, suffix, city, state, postcode));
        }
        public void RegisterClickColTime(int prodId, DateTime startTime, DateTime endTime)
        {
            clickColTimes.Add(new ClickAndCollect(prodId, startTime, endTime));
        }
        //method to update the bid information if a new bid is created
        public void UpdateBid(AccountId accountId, int prodId, string productName, string productDesc, string price, AccountId bidderId, string bidPrice, string delivery)
        {
            int index;
            DeliveryAddress deliveryAddress = GetDeliveryAddress(prodId);
            if (deliveryAddress != null)
            {
                 index = deliveryAddresses.IndexOf(deliveryAddress);
                 deliveryAddresses.RemoveAt(index);
            }
            else
            {
                ClickAndCollect clickCol = GetClickColTime(prodId);
                index = clickColTimes.IndexOf(clickCol);
                clickColTimes.RemoveAt(index);
            }
            ProductBid currentBid = GetProductBids(prodId);
            index = bids.IndexOf(currentBid);
            bids[index] = new ProductBid(accountId, prodId, productName, productDesc, price, bidderId, bidPrice, delivery);
        }
        //method to change a bid to a sale
        public void CreateSale(AccountId accountId, int prodId, string productName, string productDesc, string price, AccountId bidderId, string bidPrice, string delivery)
        {
            ProductBid currentBid = GetProductBids(prodId);
            if (currentBid != null)
            {
                int index = bids.IndexOf(currentBid);
                bids.RemoveAt(index);
                ProductListing currentlisting = GetProductListing(prodId);
                index = products.IndexOf(currentlisting);
                products.RemoveAt(index);
            }
            purchases.Add(new ProductPurchase(accountId, prodId, productName, productDesc, price, bidderId, bidPrice, delivery));
        }
        //method to track the product id
        public void increaseProductId()
        {
            productId++;
        }
        //method that sends all the lists to the database class to be processed and saved to a text file
        public void saveData()
        {
            foreach (var accountHolder in accountHolders) DataBase.SaveAccountHoldersToDb(accountHolder.ToString());
            foreach (var userAddress in userAddresses) DataBase.SaveUserAddressesToDb(userAddress.ToString());
            foreach (var product in products) DataBase.SaveProductsToDb(product.ToString());
            foreach (var bid in bids) DataBase.SaveBidsToDb(bid.ToString());
            foreach (var purchase in purchases) DataBase.SavePurchasesToDb(purchase.ToString());
            foreach (var deliveryAddress in deliveryAddresses) DataBase.SaveDeliveryAddressesToDb(deliveryAddress.ToString());
            foreach (var time in clickColTimes) DataBase.SaveTimesToDb(time.ToString());
        }
        //method to check if an account id matches one in the database
        public bool HasAccountHolder(AccountId accountId)
        {
            foreach (AccountHolder accountHolder in accountHolders)
            {
                if (accountHolder.AccountIdMatches(accountId)) return true;
            }

            return false;
        }
        //method to get the current user
        public AccountHolder GetAccountHolder(AccountId accountId, AccountPass accountPass)
        {
            foreach(AccountHolder accountHolder in accountHolders)
            {
                if (accountHolder.AccountIdMatches(accountId) & accountHolder.AccountPassMatches(accountPass)) return accountHolder;
            }

            return null;
        }
        //method to get an account via the email address
        public AccountHolder GetAccountId(AccountId accountId)
        {
            foreach (AccountHolder accountHolder in accountHolders)
            {
                if (accountHolder.AccountIdMatches(accountId)) return accountHolder;
            }

            return null;
        }
        //method to check if the user has an address saved via their email
        public bool HasAddress(AccountId accountId)
        {
            foreach (UserAddress userAddress in userAddresses)
            {
                if (userAddress.AccountIdMatches(accountId)) return true;
            }

            return false;
        }
        //method to get a users address via their email
        public UserAddress GetUserAddress(AccountId accountId)
        {
            foreach (UserAddress userAddress in userAddresses)
            {
                if (userAddress.AccountIdMatches(accountId)) return userAddress;
            }

            return null;
        }
        //method to get all items from a user where bids have been made
        public List<ProductListing> GetUserItemBids(AccountId accountId)
        {
            List<ProductListing> userItemBids = new List<ProductListing>();
            List<ProductListing> userItems = GetUserProducts(accountId);

            foreach (ProductListing item in userItems)
            {
                ProductBid bid = GetProductBids(item.ProductId);
                if (bid != null)
                {
                    userItemBids.Add(item);
                }
            }

            return userItemBids;
        }
        //method to get all products for a user
        public List<ProductListing> GetUserProducts(AccountId accountId)
        {
            List<ProductListing> userProducts = new List<ProductListing>();

            foreach (ProductListing product in products)
            {
                if (product.AccountIdMatches(accountId))
                {
                    userProducts.Add(product);
                }
            }
            return userProducts;
        }
        //method to get all products according to a search term
        public List<ProductListing> GetSearchProducts(string searchTerm)
        {
            List<ProductListing> userProducts = new List<ProductListing>();

            foreach (ProductListing product in products)
            {
                if (product.ProductNameMatches(searchTerm))
                {
                    userProducts.Add(product);
                }
            }
            return userProducts;
        }
        //method to return all products
        public List<ProductListing> GetAllProducts()
        {
            return products;
        }
        //method to get the bid on a product via the product id
        public ProductBid GetProductBids(int id)
        {
            foreach (ProductBid bid in bids)
            {
                if (bid.ProductIdMatches(id)) return bid;
            }

            return null;
        }
        //method to get the product lisitng via the id
        public ProductListing GetProductListing(int id)
        {
            foreach (ProductListing listing in products)
            {
                if (listing.ProductIdMatches(id)) return listing;
            }

            return null;
        }
        //method to get the delivery address via the product id
        public DeliveryAddress GetDeliveryAddress(int id)
        {
            foreach (DeliveryAddress deliveryAddress in deliveryAddresses)
            {
                if (deliveryAddress.ProductIdMatches(id)) return deliveryAddress;
            }
            return null;
        }
        //method to get the saved click and collect time via the product id
        public ClickAndCollect GetClickColTime(int id)
        {
            foreach (ClickAndCollect clickCol in clickColTimes)
            {
                if (clickCol.ProductIdMatches(id)) return clickCol;
            }
            return null;
        }
        //method to get all purchases via a user email
        public List<ProductPurchase> GetProductPurchases(AccountId accountId)
        {
            List<ProductPurchase> userPurchases = new List<ProductPurchase>();

            foreach (ProductPurchase purchase in purchases)
            {
                if (purchase.BidderIdMatches(accountId))
                {
                    userPurchases.Add(purchase);
                }
            }
            return userPurchases;
        }
    }
}
