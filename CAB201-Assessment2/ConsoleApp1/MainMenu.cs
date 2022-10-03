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
        const int REGISTER = 1, SIGNIN = 2, EXIT = 3;

        public MainMenu(string title, AuctionHouse house) : base(title, house)
        {
        }

        public override void Display()
        {
            while (true)
            {
                WriteLine("Please choose an option from the following list:");
                WriteLine("({0}) - Register", REGISTER);
                WriteLine("({0}) - Sign In", SIGNIN);
                WriteLine("({0}) - Exit", EXIT);

                uint option = Util.ReadUint("Please enter an integer between 1 and 3");

                if (option >= 1 && option < EXIT)
                {
                    Process(option);
                }
                else if (option == EXIT)
                {
                    break;
                }
                else
                {
                    WriteLine("Option must be greater than or equal to 1 and less than or equal to {0}.", EXIT);
                }
            }
        }

        private void Process(uint option)
        {
            if (option == REGISTER)
            {
                RegistrationDialog dlg = new RegistrationDialog("Register New Client", AuctionHouse);
                dlg.Display();
            }
            else if (option == SIGNIN)
            {
                SignInDialog dlg = new SignInDialog("Client Sign In", AuctionHouse);
                dlg.Display();
            }
        }
    }
}
