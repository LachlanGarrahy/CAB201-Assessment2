using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class UserAddress: Address
    {
        public UserAddress(AccountId accountId, uint unitNo, uint stNo, string stName, string suffix, string city, string state, uint postcode) : base(unitNo, stNo, stName, suffix, city, state, postcode)
        {
            if (IsValid(accountId, unitNo, stNo, stName, suffix, city, state, postcode))
            {
                AccountId = accountId;
            }
            else
            {
                throw new ArgumentException("User Address!");
            }
        }

        public AccountId AccountId
        {
            get;
        }

        public static bool IsValid(AccountId accountId, uint unit, uint stNo, string stName, string suffix, string city, string state, uint postcode)
        {
            return true;
        }

        public override string ToString()
        {
            return $"{AccountId},{UnitNo},{StNo},{StName},{Suffix},{City},{State},{Postcode}";
        }

        public bool AccountIdMatches(AccountId accountId) { return this.AccountId.Equals(accountId); }
    }
}
