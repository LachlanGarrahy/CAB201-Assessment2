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
			Console.WriteLine($"\n{Title}");

			string name;

			while (true)
			{
				Console.WriteLine("\nPlease enter your name");

				name = Console.ReadLine();

				if (!string.IsNullOrWhiteSpace(name))
				{
					break;
				}
			}

			AccountId email;
			email = Util.ReadAccountId("\nPlease enter your email address");

			if (AuctionHouse.HasAccountHolder(email))
			{
				Console.WriteLine("Account already exists");
				return;
			}

			AccountPass pass;
			pass = Util.ReadAccountPass("\nPlease choose a password\n" +
				"* At least 8 characters\n" +
				"* No white space characters\n" +
				"* At least one upper-case letter\n" +
				"* At least one lower-case letter\n" +
				"* At least one digit\n" +
				"* At least one special character");


			Console.WriteLine($"\nClient {name}({email}) has successfully registered at the Auction House.");
			AuctionHouse.RegisterAccountHolder(email, name, pass);

		}
	}
}
