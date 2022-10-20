using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace ConsoleApp1
{
    /// <summary>
    /// class to add everything to the database when the program is closed
    /// and initialise everything from the database at runtime
    /// </summary>
    internal class DataBase
    {
        public DataBase()
        {
            // throw new System.NotImplementedException();
        }

        private const string fileName = ("./dataSheet.txt");
        private const string DELIM = "\t";
        //methods to save the fields to the database
        public static void SaveAccountHoldersToDb(string accountHolder)
        {
            string[] fields = accountHolder.Split(DELIM);

            using StreamWriter writer = File.AppendText(fileName);

            writer.Write($"Client\t{fields[0]}\t{fields[1]}\t{fields[2]}\n");
        }
        public static void SaveUserAddressesToDb(string addresses)
        {
            string[] fields = addresses.Split(DELIM);

            using StreamWriter writer = File.AppendText(fileName);

            writer.Write($"Address\t{fields[0]}\t{fields[1]}\t{fields[2]}\t{fields[3]}\t{fields[4]}\t{fields[5]}\t{fields[6]}\t{fields[7]}\n");
        }
        public static void SaveProductsToDb(string products)
        {
            string[] fields = products.Split(DELIM);

            using StreamWriter writer = File.AppendText(fileName);

            writer.Write($"Product\t{fields[0]}\t{fields[1]}\t{fields[2]}\t{fields[3]}\t{fields[4]}\n");
        }
        public static void SaveBidsToDb(string bids)
        {
            string[] fields = bids.Split(DELIM);

            using StreamWriter writer = File.AppendText(fileName);

            writer.Write($"Bid\t{fields[0]}\t{fields[1]}\t{fields[2]}\t{fields[3]}\t{fields[4]}\t{fields[5]}\t{fields[6]}\t{fields[7]}\n");
        }
        public static void SavePurchasesToDb(string purchases)
        {
            string[] fields = purchases.Split(DELIM);

            using StreamWriter writer = File.AppendText(fileName);

            writer.Write($"Purchase\t{fields[0]}\t{fields[1]}\t{fields[2]}\t{fields[3]}\t{fields[4]}\t{fields[5]}\t{fields[6]}\t{fields[7]}\n");
        }
        public static void SaveDeliveryAddressesToDb(string addresses)
        {
            string[] fields = addresses.Split(DELIM);

            using StreamWriter writer = File.AppendText(fileName);

            writer.Write($"Delivery\t{fields[0]}\t{fields[1]}\t{fields[2]}\t{fields[3]}\t{fields[4]}\t{fields[5]}\t{fields[6]}\t{fields[7]}\n");
        }
        public static void SaveTimesToDb(string times)
        {
            string[] fields = times.Split(DELIM);

            using StreamWriter writer = File.AppendText(fileName);

            writer.Write($"ClickCol\t{fields[0]}\t{fields[1]}\t{fields[2]}\n");
        }

        //method to initialise database
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
        //method to check the lines of the text file
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
                else if (fields[0] == "Purchase") createPurchases(fields, house);
                else if (fields[0] == "Delivery") createDeliveries(fields, house);
                else if (fields[0] == "ClickCol") createTimes(fields, house);
            }
        }
        //methods to instantiate the objects and save them in runtime within the auctionhouse
        private void createClients(string[] fields, AuctionHouse house)
        {
            AccountId.TryParse(fields[1], out AccountId currentId);
            string name = fields[2];
            AccountPass.Parse(fields[3], out AccountPass currentPass);
            house.RegisterAccountHolder(currentId, name, currentPass);
        }
        private void createAddresses(string[] fields, AuctionHouse house)
        {
            AccountId.TryParse(fields[1], out AccountId currentId);
            int unitNo = int.Parse(fields[2]);
            int stNo = int.Parse(fields[3]);
            string stName = fields[4];
            string suffix = fields[5];
            string city = fields[6];
            string state = fields[7];
            int postcode = int.Parse(fields[8]);
            house.RegisterUserAddress(currentId, unitNo, stNo, stName, suffix, city, state, postcode);
        }
        private void createProducts(string[] fields, AuctionHouse house)
        {
            AccountId.TryParse(fields[1], out AccountId currentId);
            int prodId = int.Parse(fields[2]);
            string name = fields[3];
            string description = fields[4];
            string price = fields[5];
            house.RegisterExistingProduct(currentId, prodId, name, description, price);
            house.increaseProductId();
        }
        private void createBids(string[] fields, AuctionHouse house)
        {
            AccountId.TryParse(fields[1], out AccountId currentId);
            int prodId = int.Parse(fields[2]);
            string name = fields[3];
            string description = fields[4];
            string price = fields[5];
            AccountId.TryParse(fields[6], out AccountId bidderId);
            string bidPrice = fields[7];
            string delivery = fields[8];
            house.CreateBid(currentId, prodId, name, description, price, bidderId, bidPrice, delivery);
        }
        private void createPurchases(string[] fields, AuctionHouse house)
        {
            AccountId.TryParse(fields[1], out AccountId currentId);
            int prodId = int.Parse(fields[2]);
            string name = fields[3];
            string description = fields[4];
            string price = fields[5];
            AccountId.TryParse(fields[6], out AccountId bidderId);
            string bidPrice = fields[7];
            string delivery = fields[8];
            house.CreateSale(currentId, prodId, name, description, price, bidderId, bidPrice, delivery);
            house.increaseProductId();
        }
        private void createDeliveries(string[] fields, AuctionHouse house)
        {
            int prodId = int.Parse(fields[1]);
            int unitNo = int.Parse(fields[2]);
            int stNo = int.Parse(fields[3]);
            string stName = fields[4];
            string suffix = fields[5];
            string city = fields[6];
            string state = fields[7];
            int postcode = int.Parse(fields[8]);
            house.RegisterDeliveryAddress(prodId, unitNo, stNo, stName, suffix, city, state, postcode);
        }
        private void createTimes(string[] fields, AuctionHouse house)
        {
            int prodId = int.Parse(fields[1]);
            DateTime startTime = DateTime.Parse(fields[2]);
            DateTime endTime = DateTime.Parse(fields[3]);
            house.RegisterClickColTime(prodId, startTime, endTime);
        }
    }
}