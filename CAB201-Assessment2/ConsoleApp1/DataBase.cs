using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace ConsoleApp1
{
    internal class DataBase
    {
        public DataBase()
        {
            // throw new System.NotImplementedException();
        }

        private const string fileName = ("../../../dataSheet.txt");
        private const string DELIM = ",";

        public static void SaveAccountHoldersToDb(string accountHolder)
        {
            string[] fields = accountHolder.Split(DELIM);

            using StreamWriter writer = File.AppendText(fileName);

            writer.Write($"Client,{fields[0]},{fields[1]},{fields[2]}\n");
        }

        public void InitialiseDb(AuctionHouse house)
        {
            if (File.Exists(fileName))
            {
                using StreamReader reader = new StreamReader(fileName);

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] fields = line.Split(DELIM);

                    if (fields[0] == "Client")
                    {
                        AccountId currentId;
                        string name = fields[2];
                        AccountPass currentPass;
                        AccountId.TryParse(fields[1], out currentId);
                        AccountPass.TryParse(fields[3], out currentPass);
                        house.RegisterAccountHolder(currentId, name, currentPass);
                    }
                }
                reader.Close();
                File.Delete(fileName);
            }
        }

    }
}
