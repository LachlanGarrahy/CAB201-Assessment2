﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// class to create products within the system
    /// </summary>
    internal class AdvertiseProductDialog: Dialog
    {
        private AccountHolder holder;

        private string productName, productDesc, price;

        private const string PRODUCT_NAME_PROMPT = "Product name",
            PRODUCT_DESC_PROMPT = "Product description",
            PRODUCT_PRICE_PROMPT = "Product price ($d.cc)",
            PRODUCT_DESC_ERROR = "Product description cannot be the same as product name";
        public AdvertiseProductDialog(AccountHolder holder, string title, AuctionHouse house) : base(title, house)
        {
            this.holder = holder;
        }
        //method to get user input and create items within the sytsem
        public override void Display()
        {
            Console.WriteLine($"\n{Title}");

            GetProductInformation();

            Console.WriteLine($"\nSuccessfully added product {productName}, {productDesc}, {price}");

            AuctionHouse.RegisterNewProduct(holder.AccountId, productName, productDesc, price);
        }
        private void GetProductInformation()
        {

            productName = Util.getString(PRODUCT_NAME_PROMPT);
            while (true)
            {
                productDesc = Util.getString(PRODUCT_DESC_PROMPT);
                if (productDesc != productName) break;
                Console.WriteLine(PRODUCT_DESC_ERROR);
            }


            price = Util.getPrice(PRODUCT_PRICE_PROMPT);
        }
    }
}
