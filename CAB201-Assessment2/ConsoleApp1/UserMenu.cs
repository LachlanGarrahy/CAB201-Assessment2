using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    public class UserMenu : Dialog
    {
        const string ADVERTISE = "Advertise Product",
            MY_PRODUCTS = "View My Product List",
            SEARCH = "Search For Advertised Products",
            VIEW_BIDS = "View Bids On My Products",
            VIEW_PURCHASES = "View My Purchased Items",
            LOG_OFF = "Log off";

        const uint ADVERTISE_OPT = 1,
            MY_PRODUCTS_OPT = 2,
            SEARCH_OPT = 3,
            VIEW_BIDS_OPT = 4,
            VIEW_PURCHASES_OPT = 5,
            LOG_OFF_OPT = 6;

        private AccountHolder holder;

        public UserMenu(AccountHolder holder, string title, AuctionHouse house) : base(title, house)
        {
            this.holder = holder;
        }

        public override void Display()
        {
            while (true)
            {
                WriteLine($"\n{Title}");

                uint option = Util.ReadUint(ADVERTISE, MY_PRODUCTS, SEARCH, VIEW_BIDS, VIEW_PURCHASES, LOG_OFF);

                if (option == LOG_OFF_OPT)
                {
                    return;
                }

                Process(option);
            }
        }

        private void Process(uint option)
        {
            switch (option)
            {
                case ADVERTISE_OPT:
                    Advertise();
                    break;
                case MY_PRODUCTS_OPT:
                    CurrentUserProducts();
                    break;
                case SEARCH_OPT:
                    SearchProducts();
                    break;
                case VIEW_BIDS_OPT:
                    WriteLine("my bids");
                    break;
                case VIEW_PURCHASES_OPT:
                    WriteLine("purchases");
                    break;
                default:
                    // do nothing.
                    break;
            }
        }

        

        private void Advertise()
        {
            string title = $"Product Advertisement for {holder.Name}({holder.AccountId})\n";
            title = Util.addDashes(title);
            AdvertiseProductDialog advertiseDialog = new AdvertiseProductDialog(holder, title, AuctionHouse);
            advertiseDialog.Display();
        }

        private void CurrentUserProducts()
        {
            string title = $"Product List for {holder.Name}({holder.AccountId})\n";
            title = Util.addDashes(title);
            UserProductsDialog userProductDialog = new UserProductsDialog(holder, title, AuctionHouse);
            userProductDialog.Display();
        }
        private void SearchProducts()
        {
            string title = $"Product Search for {holder.Name}({holder.AccountId})\n";
            title = Util.addDashes(title);
            SearchProducts searchProductDialog = new SearchProducts(title, AuctionHouse);
            searchProductDialog.Display();
            MakeBid makeBidDialog = new MakeBid(holder, AuctionHouse, searchProductDialog.getCurrentProductList());
            makeBidDialog.Display();
        }
    }
}
