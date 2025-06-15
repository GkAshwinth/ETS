using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS
{
    public class EventTemplate
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int NoOfTickets { get; set; }
        public string CreatedBy { get; set; }
        public int IntervalDays { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan EventTime { get; set; }
    }
}
