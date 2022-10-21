using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    /// <summary>
    /// class to show the main menu and allow the user to register, sign in or quit
    /// </summary>
    public class MainMenu : Dialog
    {
        const string REGISTER = "Register",
            SIGNIN = "Sign In",
            EXIT = "Exit";

       

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
                    break;
                }

                Process(option);
            }
        }
        //method to process the user input
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
