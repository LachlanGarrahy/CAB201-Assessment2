﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SearchProducts: ProductDisplay
    {
        private List<ProductListing> products = new List<ProductListing>();
        private const string searchPrompt = "Please supply a search phrase (ALL to see all products)";
        private string searchTerm;
        public SearchProducts(string title, AuctionHouse house) : base(title, house)
        {
        }

        public override void Display()
        {
            Console.WriteLine($"\n{Title}");

            searchTerm = Util.getString(searchPrompt);

            if (searchTerm == "ALL") products = AuctionHouse.GetAllProducts();
            else products = AuctionHouse.GetSearchProducts(searchTerm);

            DisplayProducts(products);
        }

        public List<ProductListing> getCurrentProductList()
        {
            return products;
        }
    }
}
