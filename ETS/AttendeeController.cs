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
        private DBconnection connection;

        public AttendeeController()
        {
            connection = new DBconnection();
        }

        // View Events
        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();
            string query = "SELECT * FROM events";

            try
            {
                if (connection.OpenConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection.GetConnection()))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            events.Add(new Event
                            {
                                EventID = Convert.ToInt32(reader["EventID"]),
                                Name = reader["Name"].ToString(),
                                Date = Convert.ToDateTime(reader["Date"]),
                                Location = reader["Location"].ToString(),
                                Description = reader["Description"].ToString()
                            });
                        }
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

        // Updated Purchase Ticket method to fix CS0029 error
        public bool PurchaseTicket(int attendeeID, int eventID, int ticketTypeID, int quantity)
        {
            string query = $"INSERT INTO bookings (AttendeeID, EventID, TicketTypeID, Quantity, BookingDate) " +
                           $"VALUES ({attendeeID}, {eventID}, {ticketTypeID}, {quantity}, NOW())";

            try
            {
                connection.ExecuteQuery(query); // ExecuteQuery is void, so no return value
                return true; // Return true if the query executes successfully
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error purchasing ticket: " + ex.Message);
                return false; // Return false if an exception occurs
            }
        }

        // View Purchased Tickets
        public DataTable ViewMyTickets(int attendeeID)
        {
            DataTable dt = new DataTable();
            string query = $"SELECT b.BookingID, e.Name AS EventName, t.TypeName, b.Quantity, b.BookingDate " +
                           $"FROM bookings b " +
                           $"JOIN events e ON b.EventID = e.EventID " +
                           $"JOIN tickettypes t ON b.TicketTypeID = t.TicketTypeID " +
                           $"WHERE b.AttendeeID = {attendeeID}";

            try
            {
                if (connection.OpenConnection())
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection.GetConnection()))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving tickets: " + ex.Message);
            }
            finally
            {
                connection.CloseConnection();
            }

            return dt;
        }
    }
}
