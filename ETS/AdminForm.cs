using System;
using System.Windows.Forms;

namespace ETS
{
    public partial class AdminForm : Form
    {
        private User loggedInUser;

        public AdminForm(User user)
        {
            InitializeComponent();
            loggedInUser = user;
        }

        private void btnViewEvents_Click(object sender, EventArgs e)
        {
            AdminViewEventsForm eventsForm = new AdminViewEventsForm(loggedInUser);
            eventsForm.ShowDialog();
        }

        private void btnViewPayments_Click(object sender, EventArgs e)
        {
            AdminViewPaymentsForm paymentsForm = new AdminViewPaymentsForm(loggedInUser);
            paymentsForm.ShowDialog();
        }

        private void btnTrackSales_Click(object sender, EventArgs e)
        {
            AdminTrackSalesForm salesForm = new AdminTrackSalesForm(loggedInUser);
            salesForm.ShowDialog();
        }
    }
}
