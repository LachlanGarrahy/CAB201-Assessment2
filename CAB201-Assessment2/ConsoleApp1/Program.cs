namespace ConsoleApp1
{
	/// <summary>
	/// class to start the program
	/// </summary>
	internal class Program
	{
		private const string Title = "Main Menu\n" +
									"---------";
		private const string Logo = "+------------------------------+\n" +
									"| Welcome to the Auction House |\n" +
									"+------------------------------+",
							 CLOSING_TEXT = "\n+--------------------------------------------------+\n" +
											"| Good bye, thank you for using the Auction House! |\n" +
											"+--------------------------------------------------+";

		static void Main(string[] args)
		{
			Console.WriteLine(Logo);

			AuctionHouse house = new AuctionHouse();
			DataBase data = new DataBase();	
			MainMenu menu = new MainMenu(Title, house);
			data.InitialiseDb(house);
			menu.Display();
			house.saveData();

			Console.WriteLine(CLOSING_TEXT);
		}
	}
}

