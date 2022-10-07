namespace ConsoleApp1
{
	internal class Program
	{
		private const string Title = "Main menu";
		private const string Logo = "+------------------------------+\n" +
									"| Welcome to the Auction House |\n" +
									"+------------------------------+\n";

		static void Main(string[] args)
		{
			Console.WriteLine(Logo);

			AuctionHouse house = new AuctionHouse();
			DataBase data = new DataBase();	
			MainMenu menu = new MainMenu(Title, house);
			data.InitialiseDb(house);
			menu.Display();

		}
	}
}

