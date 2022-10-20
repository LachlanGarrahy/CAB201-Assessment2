using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	/// <summary>
	/// class for getting the user inputs to create the addresses
	/// </summary>
    internal class AddressDialog
    {
		AccountHolder holder;
		AuctionHouse house;

		private string[] states = { "ACT", "NSW", "NT", "QLD", "TAS", "VIC", "WA", "SA" };

		private string[] prompts = { "\nUnit number (0 = none):", "\nStreet number:", "\nStreet name:", "\nStreet suffix:", "\nCity:", "\nPostcode (1000 .. 9999):" };

		private const string UNITNOERROR = "\n\tUnit number must be a non-negative integer.",
			STNONEGATIVEERROR = "\n\tStreet number must be a positive integer",
			STNOZEROERROR = "\n\tStreet number must be greater than 0.",
			POSTCODEERROR = "\n\tPostcode must be between 1000 and 9999";

		private string stName, suffix, city, state;
		private int unitNo = -1, stNo, postcode;

		public AddressDialog(AccountHolder holder, AuctionHouse house)
		{
			this.holder = holder;
			this.house = house;
		}
		//method to create a user address
		public void createUserAddress(string title)
        {
			Console.WriteLine($"\n{title}");
			Console.WriteLine("Please provide your home address.");

			GetAddress();

			if (unitNo == 0) Console.WriteLine($"\nAddress has been updated to {stNo} {stName} {suffix}, {city} {state} {postcode}");
			else Console.WriteLine($"\nAddress has been updated to {unitNo}/{stNo} {stName} {suffix}, {city} {state} {postcode}");

			house.RegisterUserAddress(holder.AccountId, unitNo, stNo, stName, suffix, city, state, postcode);
		}
		//method to create a delivery address
		public void createDeliveryAddress(int productId)
		{
			Console.WriteLine("\nPlease provide your address.");

			GetAddress();

			if (unitNo == 0) Console.WriteLine($"\nThank you for your bid. If successful, the item will be provided via delivery to {stNo} {stName} {suffix}, {city} {state} {postcode}");
			else Console.WriteLine($"\nThank you for your bid. If successful, the item will be provided via delivery to {unitNo}/{stNo} {stName} {suffix}, {city} {state} {postcode}");

			house.RegisterDeliveryAddress(productId, unitNo, stNo, stName, suffix, city, state, postcode);
		}

		//method that calls methods to get address details and assign them to the specified fields
		private void GetAddress()
		{
			GetUnitNo();
			GetStreetNumber();
			GetStreetName();
			GetStreetSuffix();
			GetCity();
			GetState();
			GetPostcode();
		}

		private void GetUnitNo()
        {
			while (!(unitNo >= 0))
			{
				unitNo = Util.getNumber(prompts[0]);
				if (stNo < 0) Console.WriteLine(UNITNOERROR);
			}
		}
		private void GetStreetNumber()
		{
			while (!(stNo > 0))
			{
				stNo = Util.getNumber(prompts[1]);
				if (stNo == 0) Console.WriteLine(STNOZEROERROR);
				else if (stNo < 0)Console.WriteLine(STNONEGATIVEERROR);
			}
		}
		private void GetStreetName()
        {
			stName = Util.getString(prompts[2]);
		}
		private void GetStreetSuffix()
        {
			suffix = Util.getString(prompts[3]);
		}
		private void GetCity()
        {
			city = Util.getString(prompts[4]);
		}
		private void GetState()
        {
			string statePrompt = $"\nState ({states[0]}, {states[1]}, {states[2]}, {states[3]}, {states[4]}, {states[5]}, {states[6]}):";
			while (!states.Contains(state)) state = Util.getString(statePrompt).ToUpper();
		}
		private void GetPostcode()
        {
			while (!(postcode >= 1000 & postcode <= 9999))
			{
				postcode = Util.getNumber(prompts[5]);
				if (!(postcode >= 1000 & postcode <= 9999)) Console.WriteLine(POSTCODEERROR);
			}
		}
	}
}
