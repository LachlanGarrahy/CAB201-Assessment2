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
        public AdvertiseProductDialog(AccountHolder holder, string title, AuctionHouse house) : base(title, house)
        {
            this.holder = holder;
        }

        public override void Display()
        {
            Console.WriteLine($"\n{Title}");

            productName = getProductName();
            productDesc = getProductDesc();
            price = getProductPrice();

            Console.WriteLine($"\nSuccessfully added product {productName}, {productDesc}, {price}");

            AuctionHouse.RegisterProduct(holder.AccountId, productName, productDesc, price);
        }
        private string getProductName()
        {
            while (true)
            {
                Console.WriteLine("Product name");

                Console.Write("> ");
                productName = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(productName))
                {
                    break;
                }
            }
            return productName;
        }
        private string getProductDesc()
        {
            while (true)
            {
                Console.WriteLine("Product description");

                Console.Write("> ");
                productDesc = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(productDesc))
                {
                    break;
                }
            }
            return productDesc;
        }
        private string getProductPrice()
        {
            while (true)
            {
                Console.WriteLine("Product price ($d.cc)");

                Console.Write("> ");
                price = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(price))
                {
                    break;
                }
            }
            return price;
        }
    }
}
