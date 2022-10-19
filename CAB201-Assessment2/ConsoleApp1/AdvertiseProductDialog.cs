using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class AdvertiseProductDialog: Dialog
    {
        private AccountHolder holder;

        private string productName, productDesc, price;

        private const string PRODUCT_NAME_PROMPT = "\nProduct name",
            PRODUCT_DESC_PROMPT = "\nProduct description",
            PRODUCT_PRICE_PROMPT = "\nProduct price ($d.cc)",
            PRODUCT_DESC_ERROR = "\nProduct description cannot be the same as product name";
        public AdvertiseProductDialog(AccountHolder holder, string title, AuctionHouse house) : base(title, house)
        {
            this.holder = holder;
        }

        public override void Display()
        {
            Console.WriteLine($"\n{Title}");

            productName = Util.getString(PRODUCT_NAME_PROMPT);
            while (true) {
                productDesc = Util.getString(PRODUCT_DESC_PROMPT);
                if (productDesc != productName) break;
                Console.WriteLine(PRODUCT_DESC_ERROR);
            }

            
            price = Util.getPrice(PRODUCT_PRICE_PROMPT);

            Console.WriteLine($"\nSuccessfully added product {productName}, {productDesc}, {price}");

            AuctionHouse.RegisterNewProduct(holder.AccountId, productName, productDesc, price);
        }
    }
}
