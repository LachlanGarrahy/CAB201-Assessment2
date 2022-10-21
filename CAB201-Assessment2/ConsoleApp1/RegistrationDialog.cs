using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	/// <summary>
	/// class to display the dialog to allow users to register
	/// </summary>
	public class RegistrationDialog : Dialog
	{
		private const string namePrompt = "Please enter your name",
			emailPrompt = "Please enter your email address",
			passPrompt = "Please choose a password\n" +
				"* At least 8 characters\n" +
				"* No white space characters\n" +
				"* At least one upper-case letter\n" +
				"* At least one lower-case letter\n" +
				"* At least one digit\n" +
				"* At least one special character";

		public RegistrationDialog(string title, AuctionHouse house) : base(title, house)
		{
		}
		/// <summary>
		/// method to get all values and create account holder
		/// </summary>
		public override void Display()
		{
			Console.WriteLine($"\n{Title}");

			string name = GetName();

			AccountId email = GetEmail();

			if (AuctionHouse.HasAccountHolder(email))
			{
				Console.WriteLine("Account already exists");
				return;
			}

			AccountPass pass = GetAccountPass();


			Console.WriteLine($"\nClient {name}({email}) has successfully registered at the Auction House.");
			AuctionHouse.RegisterAccountHolder(email, name, pass);
		}
		//methods to get values
		private string GetName()
        {
			return Util.getString(namePrompt);
		}
		private AccountId GetEmail()
        {
			return Util.ReadAccountId(emailPrompt);
		}
		private AccountPass GetAccountPass()
        {
			return Util.ReadAccountPass(passPrompt);
		}
	}
}
