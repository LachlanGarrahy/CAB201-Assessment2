using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// class to create click and collect times
    /// </summary>
    public class ClickAndCollect
    {
        public ClickAndCollect(int id, DateTime startTime, DateTime endTime)
        {
            ProductId = id;
            StartTime = startTime;
            EndTime = endTime;
        }

        public int ProductId
        {
            get;
        }
        public DateTime StartTime
        {
            get;
        }
        public DateTime EndTime
        {
            get;
        }
        //method to convert the object to a string
        public override string ToString()
        {
            return $"{ProductId}\t{StartTime}\t{EndTime}";
        }
        //method to check if the supplied product id matches
        public bool ProductIdMatches(int id) { return this.ProductId.Equals(id); }
    }
}
