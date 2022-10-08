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
        private List<Product> products = new List<Product>();

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
            products.Add(new Product(accountId, productName, productDesc, price));
        }

        public void SaveAccountHolders()
        {
            foreach (var accountHolder in accountHolders) DataBase.SaveAccountHoldersToDb(accountHolder.ToString());
        }
        public void SaveUserAddresses()
        {
            foreach (var userAddress in userAddresses) DataBase.SaveUserAddressesToDb(userAddress.ToString());
        }
        public void SaveProducts()
        {
            foreach (var product in products) DataBase.SaveProductsToDb(product.ToString());
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

        public bool HasAddress(AccountId accountId)
        {
            foreach (UserAddress userAddress in userAddresses)
            {
                if (userAddress.AccountIdMatches(accountId)) return true;
            }

            return false;
        }

        public List<Product> GetUserProducts(AccountId accountId)
        {
            List<Product> userProducts = new List<Product>();

            foreach (Product product in products)
            {
                if (product.AccountIdMatches(accountId))
                {
                    userProducts.Add(product);
                }
            }
            return userProducts;
        }
        public List<Product> GetSearchProducts(string searchTerm)
        {
            List<Product> userProducts = new List<Product>();

            foreach (Product product in products)
            {
                if (product.ProductNameMatches(searchTerm))
                {
                    userProducts.Add(product);
                }
            }
            return userProducts;
        }
        public List<Product> GetAllProducts()
        {
            return products;
        }
    }
}
