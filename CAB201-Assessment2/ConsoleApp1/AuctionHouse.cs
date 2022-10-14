using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;



namespace ConsoleApp1
{
    public class AuctionHouse
    {
        private List<AccountHolder> accountHolders = new List<AccountHolder>();
        private List<UserAddress> userAddresses = new List<UserAddress>();
        private List<ProductListing> products = new List<ProductListing>();
        private List<ProductBid> bids = new List<ProductBid>();
        private List<DeliveryAddress> deliveryAddresses = new List<DeliveryAddress>();


        public AuctionHouse()
        {
            // throw new System.NotImplementedException();
        }

        public void RegisterAccountHolder(AccountId accountId, string name, AccountPass accountPass)
        {
            accountHolders.Add(new AccountHolder(accountId, name, accountPass));
        }
        public void RegisterUserAddress(AccountId accountId, uint unit, uint stNo, string stName, string suffix, string city, string state, uint postcode)
        {
            userAddresses.Add(new UserAddress(accountId, unit, stNo, stName, suffix, city, state, postcode));
        }
        public void RegisterProduct(AccountId accountId, string productName, string productDesc, string price)
        {
            products.Add(new ProductListing(accountId, productName, productDesc, price));
        }
        public void CreateBid(AccountId accountId, string productName, string productDesc, string price, AccountId bidderId, string bidPrice, string delivery)
        {
            bids.Add(new ProductBid(accountId, productName, productDesc, price, bidderId, bidPrice, delivery));
        }
        public void RegisterDeliveryAddress(string name, uint unit, uint stNo, string stName, string suffix, string city, string state, uint postcode)
        {
            deliveryAddresses.Add(new DeliveryAddress(name, unit, stNo, stName, suffix, city, state, postcode));
        }

        public void UpdateBid(AccountId accountId, string productName, string productDesc, string price, AccountId bidderId, string bidPrice, string delivery)
        {
            ProductBid currentBid = GetProductBids(productName);
            int index = bids.IndexOf(currentBid);
            bids[index] = (new ProductBid(accountId, productName, productDesc, price, bidderId, bidPrice, delivery));
        }

        public void saveData()
        {
            foreach (var accountHolder in accountHolders) DataBase.SaveAccountHoldersToDb(accountHolder.ToString());
            foreach (var userAddress in userAddresses) DataBase.SaveUserAddressesToDb(userAddress.ToString());
            foreach (var product in products) DataBase.SaveProductsToDb(product.ToString());
            foreach (var bid in bids) DataBase.SaveBidsToDb(bid.ToString());
            foreach (var deliveryAddress in deliveryAddresses) DataBase.SaveDeliveryAddressesToDb(deliveryAddress.ToString());
        }
        

        public bool HasAccountHolder(AccountId accountId)
        {
            foreach (AccountHolder accountHolder in accountHolders)
            {
                if (accountHolder.AccountIdMatches(accountId)) return true;
            }

            return false;
        }

        public AccountHolder GetAccountHolder(AccountId accountId, AccountPass accountPass)
        {
            foreach(AccountHolder accountHolder in accountHolders)
            {
                if (accountHolder.AccountIdMatches(accountId) & accountHolder.AccountPassMatches(accountPass)) return accountHolder;
            }

            return null;
        }

        public AccountHolder GetAccountId(AccountId accountId)
        {
            foreach (AccountHolder accountHolder in accountHolders)
            {
                if (accountHolder.AccountIdMatches(accountId)) return accountHolder;
            }

            return null;
        }

        public bool HasAddress(AccountId accountId)
        {
            foreach (UserAddress userAddress in userAddresses)
            {
                if (userAddress.AccountIdMatches(accountId)) return true;
            }

            return false;
        }

        public UserAddress GetUserAddress(AccountId accountId)
        {
            foreach (UserAddress userAddress in userAddresses)
            {
                if (userAddress.AccountIdMatches(accountId)) return userAddress;
            }

            return null;
        }

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
        public List<ProductListing> GetAllProducts()
        {
            return products;
        }

        public ProductBid GetProductBids(string name)
        {
            foreach (ProductBid bid in bids)
            {
                if (bid.ProductNameMatches(name)) return bid;
            }

            return null;
        }
    }
}
