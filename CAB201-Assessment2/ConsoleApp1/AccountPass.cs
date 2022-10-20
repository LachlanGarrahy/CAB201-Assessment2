using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    /// <summary>
    /// class to create all passwords within the system
    /// </summary>
    public class AccountPass
    {
        //password regular expression
        private const string pwdRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W)[a-zA-Z\d\w\W]{8,}$";

        public AccountPass(string password)
        {
            Password = password;
        }

        public string Password
        {
            get;
        }
        //method that runs a regex check on the supplied password
        public static bool IsValid(string password)
        {
            return RegexChecker.CheckRegex(pwdRegex, password);
        }
        //method to check if the password is valid
        //              hash the password
        //              and create the new password object
        
        public static bool TryParse(string input, out AccountPass password)
        {
            password = null;

            if (!string.IsNullOrWhiteSpace(input) && IsValid(input))
            {
                string hashedPassword = hashPassword(input);
                password = new AccountPass(hashedPassword);
            }

            return password != null;
        }
        //method to parse the values from the database to passwords within the system
        public static bool Parse(string input, out AccountPass password)
        {
            password = null;
            password = new AccountPass(input);
            return password != null;
        }
        //method to return the string value of the password
        public override string ToString()
        {
            return $"{Password}";
        }
        //method to check whether the supplied email matches this email
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
        //method to take the password as a string input and hash it
        private static string hashPassword(string password)
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

        private static string ByteArrayToString(byte[] arrInput)
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

