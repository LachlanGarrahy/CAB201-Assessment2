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
            AccountId acct = Util.ReadAccountId("Please enter the account email");

            AccountPass acctPass = Util.ReadAccountPass("Please enter the account password");

            AccountHolder holder = AuctionHouse.GetAccountHolder(acct, acctPass);

            if (holder != null)
            {

                Console.WriteLine("Congratulations, you have successfully signed in!!!");
            }

            else
            {

                Console.WriteLine("Account id not recognised...");
            }
        }
    }
}
