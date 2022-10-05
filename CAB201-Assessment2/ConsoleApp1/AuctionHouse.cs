using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;



namespace ConsoleApp1
{
    public class AuctionHouse
    {
        private List<AccountHolder> accountHolders = new List<AccountHolder>();

        private static String fileName = ("../../../dataSheet.txt");

        const string DELIM = ",";

        public AuctionHouse()
        {
            // throw new System.NotImplementedException();
        }

        public void RegisterAccountHolder(AccountId accountId, string name, AccountPass accountPass)
        {
            using StreamWriter writer = File.AppendText(fileName);

            writer.Write(new AccountHolder(accountId, name, accountPass));
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
                    string[] fields = line.Split(DELIM);

                    if (accountId.ToString() == fields[0])
                    {
                        AccountId currentId;
                        AccountPass currentPass;
                        AccountId.TryParse(fields[0], out currentId);
                        AccountPass.TryParse(fields[2], out currentPass);
                        return new AccountHolder(currentId, fields[1], currentPass);
                    }
                }
            }

            return null;
        }
    }
}
