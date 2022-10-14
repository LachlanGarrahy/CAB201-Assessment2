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
        public static void SaveUserAddressesToDb(string addresses)
        {
            string[] fields = addresses.Split(DELIM);

            using StreamWriter writer = File.AppendText(fileName);

            writer.Write($"Address,{fields[0]},{fields[1]},{fields[2]},{fields[3]},{fields[4]},{fields[5]},{fields[6]},{fields[7]}\n");
        }
        public static void SaveProductsToDb(string products)
        {
            string[] fields = products.Split(DELIM);

            using StreamWriter writer = File.AppendText(fileName);

            writer.Write($"Product,{fields[0]},{fields[1]},{fields[2]},{fields[3]}\n");
        }
        public static void SaveBidsToDb(string bids)
        {
            string[] fields = bids.Split(DELIM);

            using StreamWriter writer = File.AppendText(fileName);

            writer.Write($"Bid,{fields[0]},{fields[1]},{fields[2]},{fields[3]},{fields[4]},{fields[5]},{fields[6]}\n");
        }
        public static void SaveDeliveryAddressesToDb(string addresses)
        {
            string[] fields = addresses.Split(DELIM);

            using StreamWriter writer = File.AppendText(fileName);

            writer.Write($"Delivery,{fields[0]},{fields[1]},{fields[2]},{fields[3]},{fields[4]},{fields[5]},{fields[6]},{fields[7]}\n");
        }
        public static void SaveTimesToDb(string times)
        {
            string[] fields = times.Split(DELIM);

            using StreamWriter writer = File.AppendText(fileName);

            writer.Write($"ClickCol,{fields[0]},{fields[1]},{fields[2]}\n");
        }

        public void InitialiseDb(AuctionHouse house)
        {
            if (File.Exists(fileName))
            {
                using StreamReader reader = new StreamReader(fileName);

                checkLines(reader, house);

                reader.Close();
                File.Delete(fileName);
            }
        }

        private void checkLines(StreamReader reader, AuctionHouse house)
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] fields = line.Split(DELIM);

                if (fields[0] == "Client") createClients(fields, house);
                else if (fields[0] == "Address") createAddresses(fields, house);
                else if (fields[0] == "Product") createProducts(fields, house);
                else if (fields[0] == "Bid") createBids(fields, house);
                else if (fields[0] == "Delivery") createDeliveries(fields, house);
                else if (fields[0] == "ClickCol") createTimes(fields, house);
            }
        }
        private void createClients(string[] fields, AuctionHouse house)
        {
            AccountId.TryParse(fields[1], out AccountId currentId);
            string name = fields[2];
            AccountPass.TryParse(fields[3], out AccountPass currentPass);
            house.RegisterAccountHolder(currentId, name, currentPass);
        }
        private void createAddresses(string[] fields, AuctionHouse house)
        {
            AccountId.TryParse(fields[1], out AccountId currentId);
            uint unitNo = uint.Parse(fields[2]);
            uint stNo = uint.Parse(fields[3]);
            string stName = fields[4];
            string suffix = fields[5];
            string city = fields[6];
            string state = fields[7];
            uint postcode = uint.Parse(fields[8]);
            house.RegisterUserAddress(currentId, unitNo, stNo, stName, suffix, city, state, postcode);
        }
        private void createProducts(string[] fields, AuctionHouse house)
        {
            AccountId.TryParse(fields[1], out AccountId currentId);
            string name = fields[2];
            string description = fields[3];
            string price = fields[4];
            house.RegisterProduct(currentId, name, description, price);
        }
        private void createBids(string[] fields, AuctionHouse house)
        {
            AccountId.TryParse(fields[1], out AccountId currentId);
            string name = fields[2];
            string description = fields[3];
            string price = fields[4];
            AccountId.TryParse(fields[5], out AccountId bidderId);
            string bidPrice = fields[6];
            string delivery = fields[7];
            house.CreateBid(currentId, name, description, price, bidderId, bidPrice, delivery);
        }
        private void createDeliveries(string[] fields, AuctionHouse house)
        {
            string name = fields[2];
            uint unitNo = uint.Parse(fields[2]);
            uint stNo = uint.Parse(fields[3]);
            string stName = fields[4];
            string suffix = fields[5];
            string city = fields[6];
            string state = fields[7];
            uint postcode = uint.Parse(fields[8]);
            house.RegisterDeliveryAddress(name, unitNo, stNo, stName, suffix, city, state, postcode);
        }
        private void createTimes(string[] fields, AuctionHouse house)
        {
            string name = fields[1];
            DateTime startTime = DateTime.Parse(fields[2]);
            DateTime endTime = DateTime.Parse(fields[3]);
            house.RegisterClickColTime(name, startTime, endTime);
        }
    }
}