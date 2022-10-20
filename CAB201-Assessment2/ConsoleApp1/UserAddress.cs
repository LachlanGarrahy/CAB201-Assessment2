using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// class to instatiate the users address
    /// </summary>
    public class UserAddress: Address
    {
        public UserAddress(AccountId accountId, int unitNo, int stNo, string stName, string suffix, string city, string state, int postcode) : base(unitNo, stNo, stName, suffix, city, state, postcode)
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
