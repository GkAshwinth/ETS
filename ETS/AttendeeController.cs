using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETS
{
    internal class AttendeeController
    {
        private Database connection;

        public AttendeeController()
        {
            connection = new Database();
        }

        // View Events
        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();
            string query = "SELECT * FROM Event";

            try
            {
                MySqlConnection conn = connection.OpenConnection();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        events.Add(new Event
                        {
                            EventID = Convert.ToInt32(reader["eventId"]),
                            Name = reader["name"].ToString(),
                            Date = Convert.ToDateTime(reader["date"]),
                            Location = reader["location"].ToString(),
                            Description = reader["description"].ToString()
                        }
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading events: " + ex.Message);
            }
            finally
            {
                connection.CloseConnection();
            }

            return events;
        }

        // Purchase Ticket (insert into AttendeeTickets)
        public bool PurchaseTicket(int userId, int ticketId)
        {
            string query = $"INSERT INTO AttendeeTickets (userId, ticketId) VALUES ({userId}, {ticketId})";

            try
            {
                return connection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error purchasing ticket: " + ex.Message);
                return false;
            }
        }

        // View My Tickets (joined view)
        public DataTable ViewMyTickets(int userId)
        {
            string query = @"
                SELECT 
                    e.name AS EventName,
                    t.type AS TicketType,
                    p.status AS PaymentStatus,
                    p.amount AS PaidAmount,
                    e.date AS EventDate
                FROM AttendeeTickets at
                JOIN Ticket t ON at.ticketId = t.ticketId
                JOIN Event e ON t.eventId = e.eventId
                LEFT JOIN Payment p ON p.userId = at.userId
                WHERE at.userId = " + userId;

            return connection.ExecuteQuery(query);
        }
    }
}
