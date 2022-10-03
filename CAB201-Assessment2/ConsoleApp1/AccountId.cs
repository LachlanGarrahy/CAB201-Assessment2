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

        public AccountId(uint branchId, uint accountNum)
        {
            if (IsValid(branchId, accountNum))
            {
                BranchId = branchId;
                AccountNum = accountNum;
            }
            else
            {
                throw new ArgumentException("AccountId!");
            }
        }

        public uint BranchId
        {
            get;
        }

        public uint AccountNum
        {
            get;
        }

        public static bool IsValid(uint branchId, uint accountNum)
        {
            if (branchId < 100 || branchId >= 1000) return false;
            if (accountNum < 100000 || accountNum >= 1000000) return false;
            return true;
        }

        public static bool TryParse(string s, out AccountId account)
        {
            account = null;

            if (!string.IsNullOrWhiteSpace(s))
            {
                string[] parts = s.Split(Separator);

                if (parts.Length == 2
                    && uint.TryParse(parts[0], out uint branchId)
                    && uint.TryParse(parts[1], out uint accountNum)
                    && IsValid(branchId, accountNum)
                    )
                {

                    account = new AccountId(branchId, accountNum);
                }
            }

            return account != null;
        }

        public override string ToString()
        {
            return $"{BranchId}{Separator}{AccountNum}";
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
                return this.BranchId == other.BranchId && this.AccountNum == other.AccountNum;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BranchId, AccountNum);
        }
    }
}
