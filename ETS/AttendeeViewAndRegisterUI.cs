using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETS
{
    public partial class AttendeeViewAndRegisterUI: Form
    {
        AttendeeController attendeeController = new AttendeeController();
        public AttendeeViewAndRegisterUI()
        {
            InitializeComponent();
        }
        //ONCE LOGIN CODE IS DONE CHANGE THIS SO IT TAKES USERID FROM LOGIN DIRECTLY
        public int userId { get; set; }
        //REMEMBER

        private void LoadAvailableEvents()
        {
            var events = attendeeController.GetAllEvents();

            DataTable dt = new DataTable();
            dt.Columns.Add("EventID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Location", typeof(string));
            dt.Columns.Add("Description", typeof(string));

            foreach (var evt in events)
            {
                dt.Rows.Add(evt.EventID, evt.Name, evt.Date, evt.Location, evt.Description);
            }

            AvailableEventsDataGrid.DataSource = dt;
            AvailableEventsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            AttendeeUI attendeeUI = new AttendeeUI();
            attendeeUI.Show();
            this.Hide();
        }

        private void RegisterForEventButton_Click(object sender, EventArgs e)
        {
            if (AvailableEventsDataGrid.SelectedRows.Count > 0)
            {
                int selectedEventId = Convert.ToInt32(AvailableEventsDataGrid.SelectedRows[0].Cells["eventId"].Value);

                int? ticketId = attendeeController.GetTicketIdByEvent(selectedEventId);

                if (ticketId.HasValue)
                {
                    bool success = attendeeController.RegisterForEvent(userId, ticketId.Value);

                    if (success)
                        MessageBox.Show("Successfully registered for the event!");
                    else
                        MessageBox.Show("Failed to register. Please try again.");
                }
                else
                {
                    MessageBox.Show("No ticket found for this event.");
                }
            }
            else
            {
                MessageBox.Show("Please select an event first.");
            }
        }

        private void AttendeeViewAndRegisterUI_Load(object sender, EventArgs e)
        {
            LoadAvailableEvents();
        }
    }
}
