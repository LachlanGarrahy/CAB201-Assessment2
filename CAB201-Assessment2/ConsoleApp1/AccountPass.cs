using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AccountPass
    {
        const char Separator = '-';

        public AccountPass(string password)
        {
            if (IsValid(password))
            {
                Password = password;
            }
            else
            {
                throw new ArgumentException("AccountId!");
            }
        }

        public string Password
        {
            get;
        }

        public static bool IsValid(string password)
        {
            //password check
            return true;
        }

        public static bool TryParse(string s, out AccountPass password)
        {
            password = null;

            if (!string.IsNullOrWhiteSpace(s) && IsValid(s))
            {
                password = new AccountPass(s);
            }

            return password != null;
        }

        public override string ToString()
        {
            return $"{Password}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj is AccountId)
            {
                AccountPass other = (AccountPass)obj;
                return this.Password == other.Password;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Password);
        }
    }
}

