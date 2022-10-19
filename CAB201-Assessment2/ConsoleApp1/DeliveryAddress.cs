using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DeliveryAddress: Address
    {
        public DeliveryAddress(int id, uint unitNo, uint stNo, string stName, string suffix, string city, string state, uint postcode) : base(unitNo, stNo, stName, suffix, city, state, postcode)
        {
            ProductId = id;
        }

        public int ProductId
        {
            get;
        }

        public override string ToString()
        {
            return $"{ProductId},{UnitNo},{StNo},{StName},{Suffix},{City},{State},{Postcode}";
        }

        public bool ProductIdMatches(int id) { return this.ProductId.Equals(id); }
    }
}
