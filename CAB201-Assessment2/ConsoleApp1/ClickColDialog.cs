using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ClickColDialog
    {
		const string STARTTIMEPROMPT = "\nDelivery window start (dd/mm/yyyy hh:mm)";
		const string ENDTIMEPROMPT = "\nDelivery window end (dd/mm/yyyy hh:mm)";
		const string NOTDATEERROR = "\tPlease enter a valid date and time.";
		const string TOOEARLYSTARTERROR = "\tDelivery window start must be at least one hour in the future.";
		const string TOOEARLYENDERROR = "\tDelivery window end must be at least one hour later than the start.";
		const string SUCCESS = "\nThankyou for your bid. If successful the item will be provided via collection between {0} on {1}/{2}/{3} and {4} on {5}/{6}/{7}";

		AuctionHouse house;

		DateTime startTime;
		DateTime endTime;

		public ClickColDialog(AuctionHouse house)
		{
			this.house = house;
		}

		public void getClickColTimes(int id)
		{
			getTimes();

			house.RegisterClickColTime(id, startTime, endTime);

			Console.WriteLine(SUCCESS, startTime.TimeOfDay, startTime.Day, startTime.Month, startTime.Year, endTime.TimeOfDay, endTime.Day, endTime.Month, endTime.Year);
		}

		private void getTimes()
		{
			startTime = getTime(STARTTIMEPROMPT, TOOEARLYSTARTERROR, DateTime.Now);
			endTime = getTime(ENDTIMEPROMPT, TOOEARLYENDERROR, startTime);

		}

		private DateTime getTime(string prompt, string error, DateTime compareTime)
        {
			DateTime dateTime;
			while (true)
			{
				dateTime = Util.getDateTime(prompt, NOTDATEERROR);
				if (dateTime >= compareTime.AddHours(1)) break;
				Console.WriteLine(error);
			}
			return dateTime;
        }
	}
}

