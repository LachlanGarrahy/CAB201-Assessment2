using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AccountHolder
    {
        public AccountHolder(AccountId accountId, string name, AccountPass accountPass)
        {
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

        public bool AccountMatches(AccountId accountId)
        {
            return this.AccountId.Equals(accountId);
        }
    }
}
