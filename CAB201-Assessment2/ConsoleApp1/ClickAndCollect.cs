using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ClickAndCollect
    {
        public ClickAndCollect(string name, DateTime startTime, DateTime endTime)
        {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
        }

        public string Name
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

        public override string ToString()
        {
            return $"{Name},{StartTime},{EndTime}";
        }

        public bool ProductNameMatches(string name) { return this.Name.Equals(name); }
    }
}
