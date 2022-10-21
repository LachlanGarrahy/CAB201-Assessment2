using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// method to get user input and search products
    /// </summary>
    internal class SearchProducts: ProductDisplay
    {
        private List<ProductListing> products = new List<ProductListing>();
        private AccountHolder holder;
        private const string searchPrompt = "Please supply a search phrase (ALL to see all products)",
            errorMessage = "No items could be found for search term {0}";
        public SearchProducts(AccountHolder holder, string title, AuctionHouse house) : base(title, house)
        {
            this.holder = holder;
        }
        //method to get the product information
        public override void Display()
        {
            Console.WriteLine($"\n{Title}");

            string searchTerm = Util.getString(searchPrompt);    
            
            createCurrentProductList(searchTerm);

            Console.WriteLine("\nSearch results\n--------------");

            if (!(products.Count > 0))
            {
                DisplayNoResultError(string.Format(errorMessage, searchTerm));
                return;
            }

            products = SortProductList(products);

            DisplayProducts(products);
            MakeBid makeBidDialog = new MakeBid(holder, AuctionHouse, products);
            makeBidDialog.Display();
        }
        //method to create the product list
        private void createCurrentProductList(string searchTerm)
        {
            List <ProductListing> tempProducts = new List <ProductListing>();

            if (searchTerm.ToUpper() == "ALL") tempProducts = AuctionHouse.GetAllProducts();
            else tempProducts = AuctionHouse.GetSearchProducts(searchTerm);

            foreach(ProductListing productListing in tempProducts)
            {
                if (productListing.AccountId.ToString() != holder.AccountId.ToString())
                {
                    products.Add(productListing);
                }
            }
        }

        public List<ProductListing> getCurrentProductList()
        {
            return products;
        }
    }
}
