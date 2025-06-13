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
        public AttendeeManageTickets()
        {
            InitializeComponent();
        }
        private AttendeeController attendeeController = new AttendeeController();
        private int userId; // CHANGE THIS AFTER GETTING LOGGED IN ID PASSED THROUGH

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            AttendeeUI attendeeUI = new AttendeeUI();
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

            bool result = attendeeController.UnregisterFromEvent(userId, ticketId);

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
            DataTable tickets = attendeeController.GetMyTickets(userId);
            MyTicketsDataGrid.DataSource = tickets;
        }

        private void AttendeeManageTickets_Load(object sender, EventArgs e)
        {
            LoadMyTickets();
        }
    }
}
