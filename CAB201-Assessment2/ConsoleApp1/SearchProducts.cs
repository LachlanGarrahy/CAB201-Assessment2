using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SearchProducts: ProductDisplay
    {
        private List<ProductListing> products = new List<ProductListing>();
        private AccountHolder holder;
        private const string searchPrompt = "Please supply a search phrase (ALL to see all products)";
        private string searchTerm;
        public SearchProducts(AccountHolder holder, string title, AuctionHouse house) : base(title, house)
        {
            this.holder = holder;
        }

        public override void Display()
        {
            Console.WriteLine($"\n{Title}");

            searchTerm = Util.getString(searchPrompt);    
            
            createCurrentProductList();

            Console.WriteLine("\nSearch results\n--------------");
            
            products = SortProductList(products);

            DisplayProducts(products);
        }

        private void createCurrentProductList()
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
