using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Util
    {
		internal static uint ReadUint(string prompt)
		{
			while (true)
			{
				Console.WriteLine(prompt);
				string userInput = Console.ReadLine() ?? String.Empty;
				uint result;

				if (uint.TryParse(userInput, out result))
				{
					return result;
				}

				// Display error message...
			}
		}


		internal static AccountId ReadAccountId(string prompt)
		{
			AccountId acct;
			while (true)
			{
				Console.WriteLine(prompt);

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

				string s = Console.ReadLine();

				if (AccountPass.TryParse(s, out pass))
				{
					break;
				}
			}

			return pass;
		}
	}
}
