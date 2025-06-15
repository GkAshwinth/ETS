using System;
using System.Windows.Forms;

namespace ETS
{
    public partial class AdminViewPaymentsForm : Form
    {
        private User loggedInUser;
        private AdminController adminController;

        public AdminViewPaymentsForm(User user)
        {
            InitializeComponent();
            loggedInUser = user;
            adminController = new AdminController();
        }

        private void AdminViewPaymentsForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewPayments.DataSource = adminController.GetAllPayments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load payments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
