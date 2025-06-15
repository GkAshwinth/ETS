using ETS_event_org.Model;
using MySql.Data.MySqlClient; 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETS
{
    public class EventController
    {
        private Database database;

        public EventController()
        {
            database = new Database();
        }

        // CREATE - Add new event using parameterized queries for security
        public bool CreateEvent(Event eventObj)
        {
            try
            {
                string query = @"INSERT INTO event (name, date, location, noOfTickets, createdBy) 
                                VALUES (@name, @date, @location, @tickets, @createdBy)";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@name", eventObj.Name),
                    new MySqlParameter("@date", eventObj.Date),
                    new MySqlParameter("@location", eventObj.Location),
                    new MySqlParameter("@tickets", eventObj.NoOfTickets),
                    new MySqlParameter("@createdBy", eventObj.CreatedBy)
                };

                bool result = database.ExecuteNonQuery(query, parameters);

                if (result)
                {
                    MessageBox.Show("✅ Event created successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("❌ Failed to create event.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error creating event: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // READ - Get all events
        public List<Event> ReadEvents()
        {
            List<Event> events = new List<Event>();

            try
            {
                string query = "SELECT event_id, name, date, location, no_of_tickets, created_by FROM event ORDER BY date DESC";
                DataTable dt = database.ExecuteQuery(query);

                foreach (DataRow row in dt.Rows)
                {
                    Event eventObj = new Event(
                        Convert.ToInt32(row["event_id"]),
                        row["name"].ToString(),
                        Convert.ToDateTime(row["date"]),
                        row["location"].ToString(),
                        Convert.ToInt32(row["no_of_tickets"]),
                        row["created_by"].ToString()
                    );
                    events.Add(eventObj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error reading events: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return events;
        }

        // READ - Get event by ID (renamed from ReadEventById to match the call in EventOrganizerForm)
        public Event ReadEvent(int eventId)
        {
            try
            {
                string query = "SELECT event_id, name, date, location, no_of_tickets, created_by FROM event WHERE event_id = @eventId";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@eventId", eventId)
                };

                DataTable dt = database.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    return new Event(
                        Convert.ToInt32(row["event_id"]),
                        row["name"].ToString(),
                        Convert.ToDateTime(row["date"]),
                        row["location"].ToString(),
                        Convert.ToInt32(row["no_of_tickets"]),
                        row["created_by"].ToString()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error reading event: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        // UPDATE - Update existing event using parameterized queries
        public bool UpdateEvent(Event eventObj)
        {
            try
            {
                string query = @"UPDATE event SET 
                                name = @name, 
                                date = @date, 
                                location = @location, 
                                no_of_tickets = @tickets, 
                                created_by = @createdBy 
                                WHERE event_id = @eventId";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@name", eventObj.Name),
                    new MySqlParameter("@date", eventObj.Date),
                    new MySqlParameter("@location", eventObj.Location),
                    new MySqlParameter("@tickets", eventObj.NoOfTickets),
                    new MySqlParameter("@createdBy", eventObj.CreatedBy),
                    new MySqlParameter("@eventId", eventObj.EventID)
                };

                bool result = database.ExecuteNonQuery(query, parameters);

                if (result)
                {
                    MessageBox.Show("✅ Event updated successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("❌ Failed to update event.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error updating event: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // DELETE - Delete event using parameterized query
        public bool DeleteEvent(int eventId)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this event?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM event WHERE event_id = @eventId";

                    MySqlParameter[] parameters = {
                        new MySqlParameter("@eventId", eventId)
                    };

                    bool success = database.ExecuteNonQuery(query, parameters);

                    if (success)
                    {
                        MessageBox.Show("✅ Event deleted successfully!", "Success",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("❌ Failed to delete event.", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error deleting event: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}