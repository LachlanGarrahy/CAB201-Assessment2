using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	internal class RegisterUserAddress : Address
	{
		AccountHolder holder;
		AuctionHouse house;
		public RegisterUserAddress(AccountHolder holder, AuctionHouse house, uint unitNo, uint stNo, string stName, string suffix, string city, string state, uint postcode) : base(unitNo, stNo, stName, suffix, city, state, postcode)
		{
			this.holder = holder;
			this.house = house;
		}

		public void CreateUserAddress()
		{
			
		}
	}
}
