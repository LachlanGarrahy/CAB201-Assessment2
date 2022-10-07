using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public class RegistrationDialog : Dialog
	{
		public RegistrationDialog(string title, AuctionHouse house) : base(title, house)
		{

		}

		public override void Display()
		{
			string name;

			while (true)
			{
				Console.WriteLine("Please enter the new account name");

				name = Console.ReadLine();

				if (!string.IsNullOrWhiteSpace(name))
				{
					break;
				}
			}

			AccountId email;
			email = Util.ReadAccountId("Please enter the new account email");

			if (AuctionHouse.HasAccountHolder(email))
			{
				Console.WriteLine("Account already exists");
				return;
			}

			AccountPass pass;
			pass = Util.ReadAccountPass("Please enter the new account password");



			AuctionHouse.RegisterAccountHolder(email, name, pass);

		}
	}
}
