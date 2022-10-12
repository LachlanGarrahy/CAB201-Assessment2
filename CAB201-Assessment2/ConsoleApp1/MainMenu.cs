using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    public class MainMenu : Dialog
    {
        const string REGISTER = "Register",
            SIGNIN = "Sign In",
            EXIT = "Exit";

        const string CLOSING_TEXT = "+--------------------------------------------------+\n" +
            "| Good bye, thank you for using the Auction House! |\n" +
            "+--------------------------------------------------+";

        const uint REGISTER_OPT = 1,
            SIGNIN_OPT = 2,
            EXIT_OPT = 3;

        public MainMenu(string title, AuctionHouse house) : base(title, house)
        {
        }

        public override void Display()
        {
            while (true)
            {
                WriteLine($"\n{Title}");
                uint option = Util.ReadUint(REGISTER, SIGNIN, EXIT);

                if (option == EXIT_OPT)
                {
                    AuctionHouse.SaveAccountHolders();
                    AuctionHouse.SaveUserAddresses();
                    AuctionHouse.SaveProducts();
                    AuctionHouse.SaveBids();
                    WriteLine(CLOSING_TEXT);
                    break;
                }

                Process(option);
            }
        }

        private void Process(uint option)
        {
            switch (option)
            {
                case REGISTER_OPT:
                    RegistrationDialog reg = new RegistrationDialog("Registration\n------------", AuctionHouse);
                    reg.Display();
                    break;
                case SIGNIN_OPT:
                    SignInDialog sign = new SignInDialog("Sign In\n-------", AuctionHouse);
                    sign.Display();
                    break;
                default:
                    // do nothing.
                    break;
            }
        }
    }
}
