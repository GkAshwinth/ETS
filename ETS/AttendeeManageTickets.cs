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
    public partial class AttendeeManageTickets: Form
    {
        private int loggedInUserId;
        public AttendeeManageTickets(int UserId)
        {
            InitializeComponent();
            this.loggedInUserId = UserId;
        }
        private AttendeeController attendeeController = new AttendeeController();

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            AttendeeUI attendeeUI = new AttendeeUI(loggedInUserId);
            MessageBox.Show($"{loggedInUserId}");
            attendeeUI.Show();
            this.Hide();
        }

        private void RemoveTicketButton_Click(object sender, EventArgs e)
        {
            int selectedEventId = Convert.ToInt32(MyTicketsDataGrid.SelectedRows[0].Cells["EventID"].Value);
            int ticketId = attendeeController.GetTicketIdByEvent(selectedEventId) ?? 0;

            if (ticketId == 0)
            {
                MessageBox.Show("No ticket found for the selected event.");
                return;
            }

            bool result = attendeeController.UnregisterFromEvent(loggedInUserId, ticketId);

            if (result)
            {
                MessageBox.Show("Successfully unregistered from event.");
                LoadMyTickets();
            }
            else
            {
                MessageBox.Show("Failed to unregister from event.");
            }
        }
        private void LoadMyTickets()
        {
            DataTable tickets = attendeeController.GetMyTickets(loggedInUserId);
            MyTicketsDataGrid.DataSource = tickets;
        }

        private void AttendeeManageTickets_Load(object sender, EventArgs e)
        {
            LoadMyTickets();
        }
    }
}
