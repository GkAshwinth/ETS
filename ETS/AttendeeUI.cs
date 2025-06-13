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
    public partial class AttendeeUI: Form
    {
        private int loggedInUserId;
        public AttendeeUI(int UserId)
        {
            InitializeComponent();
            this.loggedInUserId = UserId;
        }

        private void ViewAndRegisterButton_Click(object sender, EventArgs e)
        {
            AttendeeViewAndRegisterUI viewAndRegisterUI = new AttendeeViewAndRegisterUI(loggedInUserId);
            viewAndRegisterUI.Show();
            this.Hide();
        }

        private void ManageMyTicketsButton_Click(object sender, EventArgs e)
        {
            AttendeeManageTickets manageTicketsUI = new AttendeeManageTickets(loggedInUserId);
            manageTicketsUI.Show();
            this.Hide();
        }
    }
}
