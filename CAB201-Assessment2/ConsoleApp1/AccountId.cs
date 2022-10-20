using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// class to create all the accountIds within the system
    /// </summary>
    public class AccountId
    {
        //regular expression for valid emails
        private const string emailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.+(\w){2,3})+)$";
        public AccountId(string email)
        {
            if (IsValid(email))
            {
                Email = email;
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
        //runs a regex check to ensure the email is valid
        public static bool IsValid(string email)
        {
            return RegexChecker.CheckRegex(emailRegex, email);
        }
        //parses the supplied value to an email address if its not empty and passes the regex check
        public static bool TryParse(string s, out AccountId account)
        {
            account = null;

            if (!string.IsNullOrWhiteSpace(s))
            {
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
        //method to check whether the supplied email matches this email
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
