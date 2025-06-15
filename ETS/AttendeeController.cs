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

        // ✅ View Events
        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();
            string query = "SELECT * FROM event"; // lowercase table name

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
                            AvailableTickets = Convert.ToInt32(reader["noOfTickets"]) // ✅ noOfTickets replaces Description
                        });
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

        // ✅ Register for event
        public bool RegisterForEvent(int userId, int ticketId)
        {
            string query = $"INSERT INTO AttendeeTickets (userId, ticketId) VALUES ({userId}, {ticketId})";

            try
            {
                return connection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error registering for event: " + ex.Message);
                return false;
            }
        }

        // ✅ Unregister from event
        public bool UnregisterFromEvent(int userId, int ticketId)
        {
            string query = $"DELETE FROM AttendeeTickets WHERE userId = {userId} AND ticketId = {ticketId}";

            try
            {
                return connection.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error unregistering from event: " + ex.Message);
                return false;
            }
        }

        public int? GetTicketIdByEvent(int eventId)
        {
            string query = $"SELECT ticketId FROM Ticket WHERE eventId = {eventId} LIMIT 1";
            DataTable dt = connection.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["ticketId"]);
            }
            else
            {
                return null;
            }
        }

        public DataTable GetMyTickets(int userId)
        {
            string query = $@"
            SELECT 
                e.eventId AS EventID,
                e.name AS EventName,
                t.type AS TicketType,
                e.date AS EventDate,
                t.price AS TicketPrice
            FROM AttendeeTickets at
            JOIN Ticket t ON at.ticketId = t.ticketId
            JOIN event e ON t.eventId = e.eventId
            WHERE at.userId = {userId}";

            return connection.ExecuteQuery(query);
        }
    }
}
