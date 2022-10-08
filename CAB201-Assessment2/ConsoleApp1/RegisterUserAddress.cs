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

		private string[] states = { "ACT", "NSW", "NT", "QLD", "TAS", "VIC", "WA" };

		private string stName, suffix, city, state;
		private uint unitNo, stNo, postcode;
		public RegisterUserAddress(AccountHolder holder, string title, AuctionHouse house) : base(title, house)
		{
			this.holder = holder;
		}

		public override void Display()
		{

			Console.WriteLine($"\n{Title}");

			Console.WriteLine("Please provide your home address.");

			unitNo = getUnit();
			stNo = getStNo();
			stName = getStName();
			suffix = getSuffix();
			city = getCity();
			state = getState();
			postcode = getPostcode();

			if(unitNo == 0) Console.WriteLine($"\nAddress has been updated to {stNo} {stName} {suffix}, {city} {state} {postcode}");
			else Console.WriteLine($"\nAddress has been updated to {unitNo}/{stNo} {stName} {suffix}, {city} {state} {postcode}");

			AuctionHouse.RegisterUserAddress(holder.AccountId, unitNo, stNo, stName, suffix, city, state, postcode);
		}

		private uint getUnit()
        {
			while (true)
			{
				Console.WriteLine("Unit number (0 = none):");

				if (uint.TryParse(Console.ReadLine(), out unitNo))
				{
					break;
				}
			}
			return unitNo;
		}

		private uint getStNo()
		{
			while (true)
			{
				Console.WriteLine("Street number:");

				if (uint.TryParse(Console.ReadLine(), out stNo))
				{
					break;
				}
			}
			return stNo;
		}
		private string getStName()
		{
			while (true)
			{
				Console.WriteLine("Street name:");

				stName = Console.ReadLine();

				if (!string.IsNullOrWhiteSpace(stName))
				{
					break;
				}
			}
			return stName;
		}
		private string getSuffix()
		{
			while (true)
			{
				Console.WriteLine("Street suffix:");

				suffix = Console.ReadLine();

				if (!string.IsNullOrWhiteSpace(suffix))
				{
					break;
				}
			}
			return suffix;
		}
		private string getCity()
		{
			while (true)
			{
				Console.WriteLine("City:");

				city = Console.ReadLine();

				if (!string.IsNullOrWhiteSpace(city))
				{
					break;
				}
			}
			return city;
		}
		private string getState()
		{
			while (true)
			{
				Console.WriteLine($"State ({states[0]}, {states[1]}, {states[2]}, {states[3]}, {states[4]}, {states[5]}, {states[6]}):");

				state = Console.ReadLine();

				if (!string.IsNullOrWhiteSpace(state) & states.Contains(state))
				{
					break;
				}
			}
			return state;
		}
		private uint getPostcode()
		{
			while (true)
			{
				Console.WriteLine("Postcode (1000 .. 9999):");

				if (uint.TryParse(Console.ReadLine(), out postcode) & postcode >= 1000 & postcode <= 9999)
				{
					break;
				}
			}
			return postcode;
		}
	}
}
