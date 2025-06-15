using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS
{
    public class Event
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int NoOfTickets { get; set; }
        public string CreatedBy { get; set; }
        public Event()
        {
        }

        public Event(string name, DateTime date, string location, int noOfTickets, string createdBy)
        {
            Name = name;
            Date = date;
            Location = location;
            NoOfTickets = noOfTickets;
            CreatedBy = createdBy;
        }

        public Event(int eventID, string name, DateTime date, string location, int noOfTickets, string createdBy)
        {
            EventID = eventID;
            Name = name;
            Date = date;
            Location = location;
            NoOfTickets = noOfTickets;
            CreatedBy = createdBy;
        }

        public override string ToString()
        {
            return $"ID: {EventID}, Name: {Name}, Date: {Date:yyyy-MM-dd}, Location: {Location}, Tickets: {NoOfTickets}, Created By: {CreatedBy}";
        }
    }
}

