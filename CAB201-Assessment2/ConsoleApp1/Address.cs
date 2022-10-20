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
		public int UnitNo { get; }
		public int StNo { get; }
		public int Postcode { get; }

		public Address(int unitNo, int stNo, string stName, string suffix, string city, string state, int postcode)
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
