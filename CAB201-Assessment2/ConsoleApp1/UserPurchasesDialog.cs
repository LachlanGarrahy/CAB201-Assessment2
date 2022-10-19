using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class UserPurchasesDialog: Dialog
    {
        private AccountHolder holder;
        private List<ProductPurchase> purchases = new List<ProductPurchase>();
        private string delivery;

        private const string itemDialog = "Item #\tSeller email\tProduct name\tDescription\tList Price\tAmt paid\tDelivery option";
        public UserPurchasesDialog(AccountHolder holder, string title, AuctionHouse house) : base(title, house)
        {
            this.holder = holder;
        }

        public override void Display()
        {
            Console.WriteLine($"\n{Title}");

            purchases = GetProductPurchases();

            purchases.Sort(delegate (ProductPurchase x, ProductPurchase y)
            {
                return x.Name.CompareTo(y.Name);
            });

            Console.WriteLine(itemDialog);

            for (int i = 0; i < purchases.Count; i++)
            {
                if(purchases[i].Delivery == "delivery")
                {
                    DeliveryAddress address = AuctionHouse.GetDeliveryAddress(purchases[i].Name);
                    string house;
                    if (address.UnitNo != 0) { 
                        house = $"{address.UnitNo}/{address.StNo}";
                    }
                    else
                    {
                        house = address.StNo.ToString();
                    }
                    delivery = $"Deliver to {house} {address.StName} {address.Suffix} {address.City} {address.State} {address.Postcode}";
                }
                else
                {
                    ClickAndCollect clickColTime = AuctionHouse.GetClickColTime(purchases[i].Name);
                    delivery = string.Format("Pick up between {0} on {1}/{2}/{3} and {4} on {5}/{6}/{7}",
                        clickColTime.StartTime.TimeOfDay, clickColTime.StartTime.Day, clickColTime.StartTime.Month, clickColTime.StartTime.Year,
                        clickColTime.EndTime.TimeOfDay, clickColTime.EndTime.Day, clickColTime.EndTime.Month, clickColTime.EndTime.Year);
                }

                Console.WriteLine($"{i + 1}\t{purchases[i].AccountId}\t{purchases[i].Name}\t{purchases[i].Description}\t{purchases[i].Price}\t{purchases[i].BidPrice}\t{delivery}");
            }
        }

        private List<ProductPurchase> GetProductPurchases()
        {
            return AuctionHouse.GetProductPurchases(holder.AccountId);
        }
    }
}
