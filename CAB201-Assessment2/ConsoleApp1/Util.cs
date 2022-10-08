﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Util
    {
		internal static uint ReadUint(params string[] options)
		{
			for (int i = 0; i < options.Length; i++)
			{
				Console.WriteLine("{0} - {1}", i + 1, options[i]);
			}

			while (true)
			{
				Console.WriteLine("Please enter a value between 1 and {0}", options.Length);
				string userInput = Console.ReadLine() ?? String.Empty;
				uint result;

				if (uint.TryParse(userInput, out result) && result >= 1 && result <= options.Length)
				{
					return result;
				}

				Console.WriteLine("dumb fuck");
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
