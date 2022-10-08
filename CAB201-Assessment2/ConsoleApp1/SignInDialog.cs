using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SignInDialog : Dialog
    {
        public SignInDialog(string title, AuctionHouse house) : base(title, house)
        {
            // throw new System.NotImplementedException();
        }

        public override void Display()
        {
            Console.WriteLine($"\n{Title}");

            AccountId acct = Util.ReadAccountId("\nPlease enter the account email");

            AccountPass acctPass = Util.ReadAccountPass("\nPlease enter the account password");

            AccountHolder holder = AuctionHouse.GetAccountHolder(acct, acctPass);

            if (holder != null)
            {
                UserMenu menu = new UserMenu("Client Sign In", AuctionHouse);
                menu.Display();
            }

            else
            {

                Console.WriteLine("Account id not recognised...");
            }
        }
    }
}
