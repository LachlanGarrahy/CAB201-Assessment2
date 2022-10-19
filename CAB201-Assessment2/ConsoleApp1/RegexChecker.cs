using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    internal class RegexChecker
    {
        internal static bool CheckRegex(string strRegex, string processString)
        {
            Regex re = new Regex(strRegex);

            if (re.IsMatch(processString))
                return (true);
            else
                return (false);
        }
    }
}
