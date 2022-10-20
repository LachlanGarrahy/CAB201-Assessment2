using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// class to show dialog for and allow users to sign in
    /// </summary>
    public class SignInDialog : Dialog
    {
        public SignInDialog(string title, AuctionHouse house) : base(title, house)
        {
            // throw new System.NotImplementedException();
        }
        //method to get user details and check if theyre valid
        public override void Display()
        {
            Console.WriteLine($"\n{Title}");

            AccountId acct = Util.ReadAccountId("\nPlease enter the account email");

            AccountPass acctPass = Util.ReadAccountPass("\nPlease enter the account password");

            AccountHolder holder = AuctionHouse.GetAccountHolder(acct, acctPass);

            CheckIfHolderDetailsValid(holder);
        }
        //method to check if details are in the database
        private void CheckIfHolderDetailsValid(AccountHolder holder)
        {
            if (holder != null)
            {
                if (!AuctionHouse.HasAddress(holder.AccountId)) initialiseAccountAddress(holder);
                UserMenu menu = new UserMenu(holder, "Client Menu\n-----------", AuctionHouse);
                menu.Display();
            }
            else
            {

                Console.WriteLine("\nAccount id not recognised...");
            }
        }
        //method to intialise the accounts address
        private void initialiseAccountAddress(AccountHolder holder)
        {
            string addressTitle = $"Personal Details for {holder.Name}({holder.AccountId})\n" +
                       "----------------------------------------------------------\n";
            AddressDialog registerAddress = new AddressDialog(holder, AuctionHouse);
            registerAddress.createUserAddress(addressTitle);

        }
    }
}
