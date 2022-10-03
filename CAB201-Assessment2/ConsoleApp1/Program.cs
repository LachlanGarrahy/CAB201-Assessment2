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

			AuctionHouse bank = new AuctionHouse();
			MainMenu menu = new MainMenu(Title, bank);
			menu.Display();

		}
	}
}

