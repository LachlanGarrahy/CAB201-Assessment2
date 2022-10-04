using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;



namespace ConsoleApp1
{
    public class AuctionHouse
    {
        private List<AccountHolder> accountHolders = new List<AccountHolder>();

        private static String fileName = ("../../../dataSheet.txt");

        public AuctionHouse()
        {
            // throw new System.NotImplementedException();
        }

        public void RegisterAccountHolder(AccountId accountId, string name, AccountPass accountPass)
        {
            //if (File.Exists(fileName))
            //{
            //    using StreamReader reader = new StreamReader(fileName);
            //    while (!reader.EndOfStream)
            //    {
            //        Console.WriteLine($"current line is {reader.ReadLine()}");
            //    }
            //}

            // Console.WriteLine(Directory.GetCurrentDirectory());

            accountHolders.Add(new AccountHolder(accountId, name, accountPass));

            using StreamWriter writer = File.AppendText(fileName);

            writer.Write($"{accountId}, {name}, {accountPass}");
        }

        public bool HasAccountHolder(AccountId accountId)
        {
            //foreach (AccountHolder accountHolder in accountHolders) {
            //	if (accountHolder.AccountMatches(accountId)) return true;
            //}

            //return false;

            return GetAccountHolder(accountId) != null;
        }

        public AccountHolder GetAccountHolder(AccountId accountId)
        {
            if (File.Exists(fileName))
            {
                using StreamReader reader = new StreamReader(fileName);

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                }
            }

            foreach (AccountHolder accountHolder in accountHolders)
            {
                if (accountHolder.AccountMatches(accountId)) return accountHolder;
            }

            return null;
        }
    }
}
