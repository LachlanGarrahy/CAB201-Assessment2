using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DeliveryAddress: Address
    {
        public DeliveryAddress(string name, uint unitNo, uint stNo, string stName, string suffix, string city, string state, uint postcode) : base(unitNo, stNo, stName, suffix, city, state, postcode)
        {
            if (IsValid(name, unitNo, stNo, stName, suffix, city, state, postcode))
            {
                Name = name;
            }
            else
            {
                throw new ArgumentException("Delivery Address!");
            }
        }

        public string Name
        {
            get;
        }

        public static bool IsValid(string name, uint unit, uint stNo, string stName, string suffix, string city, string state, uint postcode)
        {
            return true;
        }

        public override string ToString()
        {
            return $"{Name},{UnitNo},{StNo},{StName},{Suffix},{City},{State},{Postcode}";
        }

        public bool ProductNameMatches(string name) { return this.Name.Equals(name); }
    }
}
