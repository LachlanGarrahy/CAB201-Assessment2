using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// class to create the account holders stored within the system
    /// </summary>
    public class AccountHolder
    {
        public AccountHolder(AccountId accountId, string name, AccountPass accountPass)
        {
            // Ensures account details are valid and creates account
            if (IsValid(accountId, name, accountPass))
            {
                AccountId = accountId;
                Name = name.Trim().Replace('\t', ' ');
                AccountPass = accountPass;
            }
            else
            {
                throw new ArgumentException("AccountHolder!");
            }
        }

        public AccountId AccountId
        {
            get;
        }
        public AccountPass AccountPass
        {
            get;
        }

        public string Name
        {
            get;
        }

        public static bool IsValid(AccountId accountId, string name, AccountPass accountPass)
        {
            return accountId != null && !string.IsNullOrWhiteSpace(name);
        }

        public override string ToString()
        {
            return $"{AccountId}\t{Name}\t{AccountPass}";
        }

        //Checks if the supplied email address matches a stored account and reaturns true or false
        public bool AccountIdMatches(AccountId accountId) { return this.AccountId.Equals(accountId); }
        //Checks if the supplied password matches a stored account and reaturns true or false
        public bool AccountPassMatches(AccountPass accountPass) { return this.AccountPass.Equals(accountPass); }
    }
}
