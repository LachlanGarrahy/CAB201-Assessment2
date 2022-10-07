using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AccountId
    {
        const char Separator = '-';

        public AccountId(string branchId)
        {
            if (IsValid(branchId))
            {
                Email = branchId;
            }
            else
            {
                throw new ArgumentException("AccountId!");
            }
        }

        public string Email
        {
            get;
        }

        public static bool IsValid(string email)
        {
            //if (branchId < 100 || branchId >= 1000) return false;
            //if (accountNum < 100000 || accountNum >= 1000000) return false;
            return true;
        }

        public static bool TryParse(string s, out AccountId account)
        {
            account = null;

            if (!string.IsNullOrWhiteSpace(s))
            {
                string[] parts = s.Split(Separator);

                if (IsValid(s))
                {

                    account = new AccountId(s);
                }
            }

            return account != null;
        }

        public override string ToString()
        {
            return $"{Email}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj is AccountId)
            {
                AccountId other = (AccountId)obj;
                return this.Email == other.Email;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Email);
        }
    }
}
