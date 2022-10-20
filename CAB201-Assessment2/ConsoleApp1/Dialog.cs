using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// class to initialise the display and dialog
    /// </summary>
    public class Dialog
    {
        protected AuctionHouse AuctionHouse { get; }
        protected string Title { get; }

        public Dialog(string title, AuctionHouse house)
        {
            Title = title;
            AuctionHouse = house;
        }

        public virtual void Display()
        {
            // do nothing.
        }
    }
}
