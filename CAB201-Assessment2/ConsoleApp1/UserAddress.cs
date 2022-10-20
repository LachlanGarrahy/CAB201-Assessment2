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
            AccountId = accountId;
        }

        public AccountId AccountId
        {
            get;
        }

        public override string ToString()
        {
            return $"{AccountId}\t{UnitNo}\t{StNo}\t{StName}\t{Suffix}\t{City}\t{State}\t{Postcode}";
        }

        public bool AccountIdMatches(AccountId accountId) { return this.AccountId.Equals(accountId); }
    }
}
