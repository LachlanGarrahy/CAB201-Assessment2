using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// class to show user purchases
    /// </summary>
    internal class UserPurchasesDialog: Dialog
    {
        private AccountHolder holder;
        private List<ProductPurchase> purchases = new List<ProductPurchase>();
        private string delivery;

        private const string itemDialog = "Item #\tSeller email\tProduct name\tDescription\tList Price\tAmt paid\tDelivery option",
            errorMessage = "\n\tNo purchases could be found.";

        public UserPurchasesDialog(AccountHolder holder, string title, AuctionHouse house) : base(title, house)
        {
            this.holder = holder;
        }

        public override void Display()
        {
            Console.WriteLine($"\n{Title}");

            purchases = GetProductPurchases();

            if(!(purchases.Count > 0))
            {
                Console.WriteLine(errorMessage);
                return;
            }
            processPurchases();
        }

        private void processPurchases()
        {
            SortPurchaseList(purchases);

            Console.WriteLine(itemDialog);

            for (int i = 0; i < purchases.Count; i++)
            {
                delivery = GetDelivery(purchases[i].ProductId, purchases[i].Delivery);

                Console.WriteLine($"{i + 1}\t{purchases[i].AccountId}\t{purchases[i].Name}\t{purchases[i].Description}\t{purchases[i].Price}\t{purchases[i].BidPrice}\t{delivery}");
            }
        }
        //method to return wether the delivery is an address or time
        private string GetDelivery(int productId, string Delivery)
        {
            if (Delivery == "delivery") return GetAddress(productId);

            return GetTime(productId);
        }

        private string GetAddress(int productId)
        {
            DeliveryAddress address = AuctionHouse.GetDeliveryAddress(productId);
            string house;
            if (address.UnitNo != 0)
            {
                house = $"{address.UnitNo}/{address.StNo}";
            }
            else
            {
                house = address.StNo.ToString();
            }
            return $"Deliver to {house} {address.StName} {address.Suffix} {address.City} {address.State} {address.Postcode}";
        }

        private string GetTime(int productId)
        {
            ClickAndCollect clickColTime = AuctionHouse.GetClickColTime(productId);
            return string.Format("Pick up between {0} on {1}/{2}/{3} and {4} on {5}/{6}/{7}",
                clickColTime.StartTime.TimeOfDay, clickColTime.StartTime.Day, clickColTime.StartTime.Month, clickColTime.StartTime.Year,
                clickColTime.EndTime.TimeOfDay, clickColTime.EndTime.Day, clickColTime.EndTime.Month, clickColTime.EndTime.Year);
        }

        private List<ProductPurchase> GetProductPurchases()
        {
            return AuctionHouse.GetProductPurchases(holder.AccountId);
        }

        private List<ProductPurchase> SortPurchaseList(List<ProductPurchase> purhcasesToSort)
        {
            purhcasesToSort.OrderBy(x => x.Name)
                .ThenBy(x => x.Description)
                .ThenBy(x => x.Price)
                .ToList();

            return purhcasesToSort;
        }
    }
}
