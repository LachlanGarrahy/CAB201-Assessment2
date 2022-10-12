using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	internal class RegisterUserAddress : Dialog
	{
		AccountHolder holder;

		private string[] states = { "ACT", "NSW", "NT", "QLD", "TAS", "VIC", "WA", "SA" };

		private string[] prompts = { "Unit number (0 = none):", "Street number:", "Street name:", "Street suffix:", "City:", "Postcode (1000 .. 9999):" };
		

		private string stName, suffix, city, state;
		private uint unitNo, stNo, postcode;
		public RegisterUserAddress(AccountHolder holder, string title, AuctionHouse house) : base(title, house)
		{
			this.holder = holder;
		}

		public override void Display()
		{
			string statePrompt = $"State ({states[0]}, {states[1]}, {states[2]}, {states[3]}, {states[4]}, {states[5]}, {states[6]}):";

			Console.WriteLine($"\n{Title}");

			Console.WriteLine("Please provide your home address.");

			unitNo = Util.getNumber(prompts[0]);
			stNo = Util.getNumber(prompts[1]);
			stName = Util.getString(prompts[2]);
			suffix = Util.getString(prompts[3]);
			city = Util.getString(prompts[4]);
			while (!states.Contains(state)) state = Util.getString(statePrompt).ToUpper();
            while (!(postcode >= 1000 & postcode <= 9999)) postcode = Util.getNumber(prompts[5]);
			

			if(unitNo == 0) Console.WriteLine($"\nAddress has been updated to {stNo} {stName} {suffix}, {city} {state} {postcode}");
			else Console.WriteLine($"\nAddress has been updated to {unitNo}/{stNo} {stName} {suffix}, {city} {state} {postcode}");

			AuctionHouse.RegisterUserAddress(holder.AccountId, unitNo, stNo, stName, suffix, city, state, postcode);
		}
	}
}
