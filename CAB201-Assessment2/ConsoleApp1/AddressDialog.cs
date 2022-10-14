using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class AddressDialog
    {
		AccountHolder holder;
		AuctionHouse house;

		private string[] states = { "ACT", "NSW", "NT", "QLD", "TAS", "VIC", "WA", "SA" };

		private string[] prompts = { "Unit number (0 = none):", "Street number:", "Street name:", "Street suffix:", "City:", "Postcode (1000 .. 9999):" };

		private string stName, suffix, city, state;
		private uint unitNo, stNo, postcode;

		private Address address;
		public AddressDialog(AccountHolder holder, AuctionHouse house)
		{
			this.holder = holder;
			this.house = house;
		}

		public void createUserAddress(string title)
        {
			Console.WriteLine($"\n{title}");
			Console.WriteLine("Please provide your home address.");

			GetAddress();

			if (unitNo == 0) Console.WriteLine($"\nThank you for your bid. If successful, the item will be provided via delivery to {stNo} {stName} {suffix}, {city} {state} {postcode}");
			else Console.WriteLine($"\nThank you for your bid. If successful, the item will be provided via delivery to {unitNo}/{stNo} {stName} {suffix}, {city} {state} {postcode}");

			house.RegisterUserAddress(holder.AccountId, unitNo, stNo, stName, suffix, city, state, postcode);
		}

		public void createDeliveryAddress(string name)
		{
			Console.WriteLine("Please provide your address.");

			GetAddress();

			if (unitNo == 0) Console.WriteLine($"\nAddress has been updated to {stNo} {stName} {suffix}, {city} {state} {postcode}");
			else Console.WriteLine($"\nAddress has been updated to {unitNo}/{stNo} {stName} {suffix}, {city} {state} {postcode}");

			house.RegisterDeliveryAddress(name, unitNo, stNo, stName, suffix, city, state, postcode);
		}

		private void GetAddress()
		{
			string statePrompt = $"State ({states[0]}, {states[1]}, {states[2]}, {states[3]}, {states[4]}, {states[5]}, {states[6]}):";

			unitNo = Util.getNumber(prompts[0]);
			stNo = Util.getNumber(prompts[1]);
			stName = Util.getString(prompts[2]);
			suffix = Util.getString(prompts[3]);
			city = Util.getString(prompts[4]);
			while (!states.Contains(state)) state = Util.getString(statePrompt).ToUpper();
			while (!(postcode >= 1000 & postcode <= 9999)) postcode = Util.getNumber(prompts[5]);
		}
	}
}
