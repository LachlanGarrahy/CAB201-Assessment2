using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    internal class Util
    {
		private const string price_regex = @"^\$\d+.\d\d$";
		internal static uint ReadUint(params string[] options)
		{
			for (int i = 0; i < options.Length; i++)
			{
				Console.WriteLine("{0} - {1}", i + 1, options[i]);
			}

			while (true)
			{
				Console.WriteLine("\nPlease enter a value between 1 and {0}", options.Length);
				Write("> ");
				string userInput = Console.ReadLine() ?? String.Empty;
				uint result;

				if (uint.TryParse(userInput, out result) && result >= 1 && result <= options.Length)
				{
					return result;
				}
			}
		}


		internal static AccountId ReadAccountId(string prompt)
		{
			AccountId acct;
			while (true)
			{
				Console.WriteLine(prompt);

				Write("> ");
				string s = Console.ReadLine();

				if (AccountId.TryParse(s, out acct))
				{
					break;
				}
			}

			return acct;
		}

		internal static AccountPass ReadAccountPass(string prompt)
		{
			AccountPass pass;
			while (true)
			{
				Console.WriteLine(prompt);

				Write("> ");
				string s = Console.ReadLine();

				if (AccountPass.TryParse(s, out pass))
				{
					break;
				}
			}

			return pass;
		}

		public static string getString(string prompt)
		{
			string searchTerm;
			while (true)
			{
				Console.WriteLine(prompt);

				Write("> ");
				searchTerm = Console.ReadLine();

				if (!string.IsNullOrWhiteSpace(searchTerm))
				{
					break;
				}
			}
			return searchTerm;
		}

		public static uint getNumber(string prompt)
        {
			uint number;
			while (true)
			{
				Console.WriteLine(prompt);
				Write("> ");

				if (uint.TryParse(Console.ReadLine(), out number))
				{
					break;
				}
			}
			return number;
		}
		public static string getPrice(string prompt)
        {
			string price;
			while (true)
			{
				Console.WriteLine(prompt);

				Write("> ");
				price = Console.ReadLine();

				if (!string.IsNullOrWhiteSpace(price) & RegexChecker.CheckRegex(price_regex, price))
				{
					break;
				}
			}
			return price;
		}

		public static DateTime getDateTime(string prompt, string error)
        {
			DateTime dateTime;
			while (true)
			{
				Console.WriteLine(prompt);
				Write("> ");

				if (DateTime.TryParse(Console.ReadLine(), out dateTime))
				{
					break;
				}
				Console.WriteLine(error);
			}
			return dateTime;
		}

		public static string addDashes(string title)
		{
			int length = title.Length;
			for (int i = 1; i < length; i++)
			{
				title += "-";
			}
			title += "\n";
			return title;
		}
	}
}
