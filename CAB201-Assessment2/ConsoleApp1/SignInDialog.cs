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
        private const string emailPrompt = "Please enter the account email",
                            passPrompt = "Please enter the account password",
                            clientMenu = "Client Menu\n-----------",
                            notRecognisedError = "\nAccount id not recognised...",
                            accountAddressPrompt = "Personal Details for {0}({1})\n" +
                                                    "----------------------------------------------------------\n";

        public SignInDialog(string title, AuctionHouse house) : base(title, house)
        {
            // throw new System.NotImplementedException();
        }
        //method to get user details and check if theyre valid
        public override void Display()
        {
            Console.WriteLine($"\n{Title}");

            AccountId acct = Util.ReadAccountId(emailPrompt);

            AccountPass acctPass = Util.ReadAccountPass(passPrompt);

            AccountHolder holder = AuctionHouse.GetAccountHolder(acct, acctPass);

            CheckIfHolderDetailsValid(holder);
        }
        //method to check if details are in the database
        private void CheckIfHolderDetailsValid(AccountHolder holder)
        {
            if (holder != null)
            {
                if (!AuctionHouse.HasAddress(holder.AccountId)) initialiseAccountAddress(holder);
                UserMenu menu = new UserMenu(holder, clientMenu, AuctionHouse);
                menu.Display();
            }
            else
            {

                Console.WriteLine(notRecognisedError);
            }
        }
        //method to intialise the accounts address
        private void initialiseAccountAddress(AccountHolder holder)
        {
            string addressTitle = string.Format(accountAddressPrompt, holder.Name, holder.AccountId);
            AddressDialog registerAddress = new AddressDialog(holder, AuctionHouse);
            registerAddress.createUserAddress(addressTitle);

        }
    }
}
