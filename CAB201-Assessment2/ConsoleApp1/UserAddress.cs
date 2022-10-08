using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class UserAddress
    {
        public UserAddress(AccountId accountId, uint unit, uint stNo, string stName, string suffix, string city, string state, uint postcode)
        {
            if (IsValid(accountId, unit, stNo, stName, suffix, city, state, postcode))
            {
                AccountId = accountId;
                Unit = unit;
                StNo = stNo;
                StName = stName;
                Suffix = suffix;
                City = city;
                State = state;
                Postcode = postcode;
            }
            else
            {
                throw new ArgumentException("Address!");
            }
        }

        public AccountId AccountId
        {
            get;
        }
        public uint Unit
        {
            get;
        }

        public uint StNo
        {
            get;
        }
        public string StName
        {
            get;
        }
        public string Suffix
        {
            get;
        }

        public string City
        {
            get;
        }

        public string State
        {
            get;
        }

        public uint Postcode
        {
            get;
        }

        public static bool IsValid(AccountId accountId, uint unit, uint stNo, string stName, string suffix, string city, string state, uint postcode)
        {
            return true;
        }

        public override string ToString()
        {
            return $"{AccountId},{Unit},{StNo},{StName},{Suffix},{City},{State},{Postcode}";
        }

        public bool AccountIdMatches(AccountId accountId) { return this.AccountId.Equals(accountId); }
    }
}
