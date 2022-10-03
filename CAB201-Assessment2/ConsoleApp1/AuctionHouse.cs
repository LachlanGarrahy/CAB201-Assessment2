using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    public class AuctionHouse
    {
        private List<AccountHolder> accountHolders = new List<AccountHolder>();

        private static String fileName = ("./dataSheet.txt");

        public AuctionHouse()
        {
            // throw new System.NotImplementedException();
        }

        public void RegisterAccountHolder(AccountId accountId, string name, AccountPass accountPass)
        {
            if (File.Exists(fileName))
            {
                using StreamReader reader = new StreamReader(fileName);
                while (!reader.EndOfStream)
                { 
                    Console.WriteLine($"current line is {reader.ReadLine()}");
                }
            }

            accountHolders.Add(new AccountHolder(accountId, name, accountPass));

            File.WriteAllText(fileName, (accountId + name + accountPass));
            
            
            Console.WriteLine(accountHolders);
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
