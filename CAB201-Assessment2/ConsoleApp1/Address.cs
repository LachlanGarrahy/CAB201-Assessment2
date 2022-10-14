using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Address
    {
		public string StName { get; }
		public string Suffix { get; }
		public string City { get; }
		public string State { get; }
		public uint UnitNo { get; }
		public uint StNo { get; }
		public uint Postcode { get; }

		public Address(uint unitNo, uint stNo, string stName, string suffix, string city, string state, uint postcode)
		{
			StName = stName;
			Suffix = suffix;
			City = city;
			State = state;
			UnitNo = unitNo;
			StNo = stNo;
			Postcode = postcode;
		}
	}
}
