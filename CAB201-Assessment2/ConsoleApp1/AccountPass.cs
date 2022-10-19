using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    public class AccountPass
    {
        private const string pwdRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W)[a-zA-Z\d\w\W]{8,}$";

        public AccountPass(string password)
        {
            if (IsValid(password))
            {
                string hashedPassword = hashPassword(password);
                Password = hashedPassword;
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
            return RegexChecker.CheckRegex(pwdRegex, password);
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
            else if (obj is AccountPass)
            {
                AccountPass other = (AccountPass)obj;
                return this.Password == other.Password;
            }
            else
            {
                return false;
            }
        }
        private string hashPassword(string password)
        {
            string sSourceData;
            byte[] tmpSource;
            byte[] tmpHash;

            sSourceData = password;
            //Create a byte array from source data.
            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
            //Compute hash based on source data.
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            return ByteArrayToString(tmpHash);
        }

        private string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(Password);
        }
    }
}

